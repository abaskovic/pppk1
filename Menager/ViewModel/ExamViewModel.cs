using Menager.Dal;
using Menager.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

namespace Menager.ViewModel
{
    public class ExamViewModel
    {
        public ObservableCollection<Exam> Exam { get; }

        public ExamViewModel()
        {
            Exam = new ObservableCollection<Exam>(
            RepositoryFactory.GetRepository.GetExams());
            Exam.CollectionChanged += Exam_CollectionChange;
        }

        private void Exam_CollectionChange(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository.AddExam(
                        Exam[e.NewStartingIndex]);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository.DeleteExam(
                        e.OldItems!.OfType<Exam>().ToList()[0].IdExam);
                    break;
                case NotifyCollectionChangedAction.Replace:

                    Debug.WriteLine(e.NewItems!.OfType<Exam>().ToList()[0].IdExam);
                    Debug.WriteLine(e.NewItems!.OfType<Exam>().ToList());

                    RepositoryFactory.GetRepository.UpdateExam(
                        e.NewItems!.OfType<Exam>().ToList()[0]);
                    break;

            }
        }
        public void UpdateExam(Exam exam) => Exam[Exam.IndexOf(exam)] = exam;
    }
}
