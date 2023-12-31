﻿using Menager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Menager
{
    public class FramePage:Page
    {
        public FramePage(ExamViewModel examViewModel, ProfessorViewModel professorViewModel, StudentViewModel studentViewModel)
        {
            ExamViewModel = examViewModel;
            StudentViewModel = studentViewModel;
            ProfessorViewModel = professorViewModel;

        }

        public ExamViewModel ExamViewModel { get; }
        public ProfessorViewModel ProfessorViewModel { get; }
        public StudentViewModel StudentViewModel { get; }
        public Frame? Frame { get; set; }
    }
}
