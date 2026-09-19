using System.Data;
using System.Security.Cryptography.Xml;
using MySqlConnector;
using ProjectManager.Api.Data;
using ProjectManager.Api.Models;

namespace ProjectManager.Api.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public ProjectRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        var projects = new List<Project>();

        await using var connection = _dbConnectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using var command = new MySqlCommand("SP_Project_GetAll", connection);

        command.CommandType = CommandType.StoredProcedure;

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
}
