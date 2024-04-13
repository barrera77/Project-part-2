using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using StarTEDSystemDB.BLL;
using StarTEDSystemDB.Entities;

namespace StarTEDSystemWebApp.Components.Pages
{
    public partial class CRUD
    {
        [Inject]
        IJSRuntime JSRuntime { get; set; }

        [Inject]
        ProgramServices ProgramServices { get; set; }
        [Inject]
        ProgramCourseServices ProgramCourseServices { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        
        [Parameter]
        public int ProgramCourseId { get; set; }        
        [Parameter]
        public string CourseName { get; set; }  


        public List<StarTEDSystemDB.Entities.Program> Programs { get; set; }
        public List<ProgramCourse> ProgramCourses { get; set; }

        private ProgramCourse ProgramCourse { get; set; }
        
        public List<string> errorList = new List<string>();
        public string feedback { get; set; }


        /// <summary>
        /// Initialize processes
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Deactivate a ProgramCourse and display an alert for confirmation
        /// </summary>
        /// <returns></returns>
        private async Task HandleDeactivate()
        {
            if (ProgramCourse.ProgramCourseId != 0)
            {
                // Make a JS call to confirm whether to deactivate or not
                object[] message = new[] { "Are you sure you want to deactivate this course?"};

                if(await JSRuntime.InvokeAsync<bool>("confirm", message))
                {
                    try
                    {
                        feedback = "Course succesfully deactivated";
                    }
                    catch (Exception e)
                    {
                        errorList.Add(e.Message);
                    }
                }

            }
        }
    }
}
