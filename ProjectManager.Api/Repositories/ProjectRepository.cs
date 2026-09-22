using System.Data;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
using Microsoft.VisualBasic;
using MySqlConnector;
using ProjectManager.Api.Data;
using ProjectManager.Api.DTOs;
using ProjectManager.Api.Models;

namespace ProjectManager.Api.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public ProjectRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<Project>> GetAllAsync(int createdByUserId)
    {
        var projects = new List<Project>();

        await using var connection = _dbConnectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using var command = new MySqlCommand("SP_Project_GetAll", connection);

        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("p_created_by_user_id", createdByUserId);

        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            projects.Add(new Project
            {
               ProjectId = reader.GetInt32("project_id"),
               ProjectName = reader.GetString("project_name"),
               PriorityId = reader.GetInt32("priority_id"),
               ProjectStatusId = reader.GetInt32("project_status_id"),
               ProjectCreatedDate = reader.GetDateTime("project_created_date"),
               ProjectDueDate = reader.IsDBNull("project_due_date") ? null : reader.GetDateTime("project_due_date"),
               Comments = reader.IsDBNull("comments") ? null : reader.GetString("comments"),
               CreatedByUserId = reader.GetInt32("created_by_user_id"),
               LogicalCancelValue = reader.GetInt32("logical_cancel_value"),
               ProjectCompleteDate = reader.IsDBNull("project_complete_date") ? null : reader.GetDateTime("project_complete_date")
            });
        }
        return projects;
    }

    public async Task<int> CreateAsync(CreateProjectRequest request, int createdByUserId)
    {
        await using var connection = _dbConnectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using var command = new MySqlCommand("SP_Project_Insert", connection);

        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("p_project_name", request.ProjectName);

        command.Parameters.AddWithValue("p_priority_id", request.PriorityId);

        command.Parameters.AddWithValue("p_project_status_id", request.ProjectStatusId);

        command.Parameters.AddWithValue("p_project_due_date", request.ProjectDueDate);

        command.Parameters.AddWithValue("p_comments", request.Comments);

        command.Parameters.AddWithValue("p_created_by_user_id", createdByUserId);

        var result = await command.ExecuteScalarAsync();

        return Convert.ToInt32(result);
    }

    public async Task<bool> UpdateAsync(int projectId, CreateProjectRequest request, int createdByUserId)
    {
        await using var connection = _dbConnectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using var command = new MySqlCommand("SP_Project_Update", connection);

        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("p_project_id", projectId);

        command.Parameters.AddWithValue("p_project_name", request.ProjectName);

        command.Parameters.AddWithValue("p_priority_id", request.PriorityId);

        command.Parameters.AddWithValue("p_project_status_id", request.ProjectStatusId);

        command.Parameters.AddWithValue("p_project_due_date", request.ProjectDueDate);

        command.Parameters.AddWithValue("p_comments", request.Comments);

        command.Parameters.AddWithValue("p_created_by_user_id", createdByUserId);

        var result = await command.ExecuteScalarAsync();

        return Convert.ToInt32(result) > 0;
    }

    public async Task<bool> DeleteAsync(int projectId, int createdByUserId)
    {
        await using var connection = _dbConnectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using var command = new MySqlCommand("SP_Project_Delete", connection);

        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("p_project_id", projectId);

        command.Parameters.AddWithValue("p_created_by_user_id", createdByUserId);

        var result = await command.ExecuteScalarAsync();

        return Convert.ToInt32(result) > 0;
    }

    public async Task<bool> CompleteAsync(int projectId, int createdByUserId)
    {
        await using var connection = _dbConnectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using var command = new MySqlCommand("SP_Project_Complete", connection);

        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("p_project_id", projectId);

        command.Parameters.AddWithValue("p_created_by_user_id", createdByUserId);

        var result = await command.ExecuteScalarAsync();

        return Convert.ToInt32(result) > 0;
    }
}
