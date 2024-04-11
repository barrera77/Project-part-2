using Microsoft.AspNetCore.Components;
using StarTEDSystemDB.BLL;
using StarTEDSystemDB.Entities;

namespace StarTEDSystemWebApp.Components.Pages
{
    public partial class CRUD
    {
        [Inject]
        ProgramServices ProgramServices { get; set; }

        [Inject]
        ProgramCourseServices ProgramCourseServices { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        //Required properties
        [Parameter]
        public int ProgramCourseId { get; set; }
        
        [Parameter]
        public string CourseName { get; set; }  


        public List<StarTEDSystemDB.Entities.Program> Programs { get; set; }
        public List<ProgramCourse> ProgramCourses { get; set; }
        
        private ProgramCourse ProgramCourse { get; set; }

        public List<string> errorList = new List<string>();
        public string feedback { get; set; }

        protected override Task OnInitializedAsync()
        {
            ProgramCourse = new();
            ProgramCourses = new();

            if (ProgramCourseId != 0)
            {
                ProgramCourses = ProgramCourseServices.GetAllProgramCourses(ProgramCourseId);
                ProgramCourse = ProgramCourseServices.GetProgramCourseById(ProgramCourseId);

                if (ProgramCourse == null)
                {
                    errorList.Add($"No course found for id {ProgramCourse.CourseId}");
                }
            }

            return base.OnInitializedAsync();
        }
    }
}
