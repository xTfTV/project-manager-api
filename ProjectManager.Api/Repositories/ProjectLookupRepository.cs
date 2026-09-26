using System.Data;
using Microsoft.VisualBasic;
using MySqlConnector;
using ProjectManager.Api.Data;
using ProjectManager.Api.DTOs;

namespace ProjectManager.Api.Repositories;

public class ProjectLookupRepository : IProjectLookupRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public ProjectLookupRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<PriorityResponse>> GetPrioritiesAsync()
    {
        var priorities = new List<PriorityResponse>();

        await using var connection = _dbConnectionFactory.CreateConnection();

        await connection.OpenAsync();

        await using var command = new MySqlCommand("SP_Priority_GetAll", connection);

        command.CommandType = CommandType.StoredProcedure;

        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            priorities.Add(new PriorityResponse
            {
                PriorityId = reader.GetInt32("priority_id"),
                PriorityName = reader.GetString("priority_name")
            });
        }

        return priorities;
    }

    public async Task<IEnumerable<ProjectStatusResponse>> GetStatusesAsync()
    {
        var statuses = new List<ProjectStatusResponse>();

        await using var connection = _dbConnectionFactory.CreateConnection();

        await connection.OpenAsync();

        await using var command = new MySqlCommand("SP_ProjectStatus_GetAll", connection);

        command.CommandType = CommandType.StoredProcedure;

        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            statuses.Add(new ProjectStatusResponse
            {
                ProjectStatusId = reader.GetInt32("project_status_id"),
                ProjectStatusName = reader.GetString("project_status_name")
            });
        }

        return statuses;
    }
}
