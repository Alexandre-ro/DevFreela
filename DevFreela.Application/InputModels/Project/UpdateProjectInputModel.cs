﻿namespace DevFreela.Application.InputModels.Project
{
    public class UpdateProjectInputModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCoast { get; set; }
    }
}
