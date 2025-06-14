using StatisticsService.Api.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/statistics")]
public class StatisticsController : ControllerBase
{
    private readonly StatisticService _statisticsService;

    public StatisticsController(StatisticService statisticsService)
    {
        _statisticsService = statisticsService;
    }

    [HttpGet("repairs-per-month")]
    public async Task<ActionResult<Dictionary<int, int>>> GetRepairsPerMonth()
    {
        return Ok(await _statisticsService.GetRepairsPerMonthAsync());
    }

    [HttpGet("repairs-per-year")]
    public async Task<ActionResult<Dictionary<int, int>>> GetRepairsPerYear()
    {
        return Ok(await _statisticsService.GetRepairsPerYearAsync());
    }

    [HttpGet("popular-marks")]
    public async Task<ActionResult<Dictionary<string, int>>> GetPopularCarMarks()
    {
        return Ok(await _statisticsService.GetPopularCarMarksAsync());
    }
}