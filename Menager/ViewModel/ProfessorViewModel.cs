using Menager.Dal;
using Menager.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Menager.ViewModel
{
    public class ProfessorViewModel
    {
        public ObservableCollection<Professor> Professor { get; }

        public ProfessorViewModel()
        {
            Professor = new ObservableCollection<Professor>(
            RepositoryFactory.GetRepository.GetProfessors());
            Professor.CollectionChanged += Professor_CollectionChange;
        }

        private void Professor_CollectionChange(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository.addProfessor(
                        Professor[e.NewStartingIndex]);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository.deleteProfessor(
                        e.OldItems!.OfType<Professor>().ToList()[0].IdProfessor);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository.deleteProfessor(
                        e.NewItems!.OfType<Professor>().ToList()[0].IdProfessor);
                    break;

            }
        }
        public void UpdateProfessor(Professor exam) => Professor[Professor.IndexOf(exam)] = exam;

    }
}
