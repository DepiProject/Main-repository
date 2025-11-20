using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCampus.App.Dtos;
using SmartCampus.Core.Entities;


namespace SmartCampus.App.Services.IServices
{
   public interface ISubmissionService
   {

        // Start & submit exam
        Task<ExamSubmissionDto> StartExamAsync(int examId, int studentId);
        Task<ExamResultDto> SubmitExamAsync(SubmitExamDto dto);

        // Get results
        Task<ExamResultDto?> GetExamResultAsync(int examId, int studentId);
        Task<ExamSubmissionDto?> GetSubmissionStatusAsync(int examId, int studentId);

        // Get student submissions
        Task<IEnumerable<ExamSubmissionDto>> GetStudentSubmissionsAsync(int studentId);

        // Get exam submissions (for instructors)
        Task<IEnumerable<ExamResultDto>> GetExamSubmissionsAsync(int examId);
    }
}
