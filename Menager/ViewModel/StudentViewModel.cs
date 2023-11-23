using Menager.Dal;
using Menager.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Menager.ViewModel
{
    public class StudentViewModel
    {
        public ObservableCollection<Student> Student { get; }

        public StudentViewModel()
        {
            Student = new ObservableCollection<Student>(
            RepositoryFactory.GetRepository.GetStudents());
            Student.CollectionChanged += Student_CollectionChange;
        }

        private void Student_CollectionChange(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository.addStudent(
                        Student[e.NewStartingIndex]);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository.deleteStudent(
                        e.OldItems!.OfType<Student>().ToList()[0].IdStudent);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository.deleteStudent(
                        e.NewItems!.OfType<Student>().ToList()[0].IdStudent);
                    break;

            }
        }
        public void UpdateStudent(Student exam) => Student[Student.IndexOf(exam)] = exam;

    }
}
