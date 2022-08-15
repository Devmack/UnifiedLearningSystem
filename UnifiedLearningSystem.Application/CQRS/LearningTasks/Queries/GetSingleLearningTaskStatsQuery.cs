using MediatR;
using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Application.Shared.Statistics;

namespace UnifiedLearningSystem.Application.CQRS.LearningTasks.Queries
{
    public class GetSingleLearningTaskStatsQuery : IRequest<LearningTaskStatsDTO>
    {
        private readonly Guid targetTaskId;

        public GetSingleLearningTaskStatsQuery(Guid targetTaskId)
        {
            this.targetTaskId = targetTaskId;
        }

        public class GetSingleLearningTaskStatsQueryHandler : IRequestHandler<GetSingleLearningTaskStatsQuery, LearningTaskStatsDTO>
        {
            private readonly IStatsService statsService;

            public GetSingleLearningTaskStatsQueryHandler(IStatsService statsService)
            {
                this.statsService = statsService;
            }

            public async Task<LearningTaskStatsDTO> Handle(GetSingleLearningTaskStatsQuery request, CancellationToken cancellationToken)
            {
                var targetSubmissionCount = await statsService.GetSubmissionCountAsync(request.targetTaskId);
                return new LearningTaskStatsDTO() { TotalSubmissionCount = targetSubmissionCount };
            }
        }
    }
}
