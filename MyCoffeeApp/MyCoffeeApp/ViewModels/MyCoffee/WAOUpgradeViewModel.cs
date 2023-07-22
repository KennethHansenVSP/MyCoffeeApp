using MvvmHelpers;
using MvvmHelpers.Commands;
using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.Views;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace MyCoffeeApp.ViewModels
{
    public class WAOUpgradeViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Buildings> BuildingsColl { get; set; }
        public ObservableRangeCollection<GrowtRequirements> GrowtRequirements { get; set; }
        public ObservableRangeCollection<BuildingLevels> Levels { get; set; }

        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Buildings> SelectedCommand { get; }

        IWaoService waoService;

        public WAOUpgradeViewModel()
        {

            Title = "WAO Upgrade";

            BuildingsColl = new ObservableRangeCollection<Buildings>();
            GrowtRequirements = new ObservableRangeCollection<GrowtRequirements>();
            Levels = new ObservableRangeCollection<BuildingLevels>();

            RefreshCommand = new AsyncCommand(Refresh);
            SelectedCommand = new AsyncCommand<Buildings>(Selected);

            waoService = DependencyService.Get<IWaoService>();
        }
        Buildings selectedBuilding;

        public  Buildings SelectedBuilding
        {
            get { return selectedBuilding; }
            set
            {
                if (selectedBuilding != value)
                {
                    selectedBuilding = value;
                    if (selectedLevel != null) 
                        GetGrowtRequirementsLevel(selectedBuilding.Id, selectedLevel.Level);
                    else
                        GetGrowtRequirementsLevel(selectedBuilding.Id);
                    OnPropertyChanged();
                }
            }
        }
        BuildingLevels selectedLevel;

        public BuildingLevels SelectedLevel
        {
            get { return selectedLevel; }
            set
            {
                if (selectedLevel != value )
                {
                    selectedLevel = value;
                    if (SelectedBuilding != null)
                        GetGrowtRequirementsLevel(selectedBuilding.Id, selectedLevel.Level);
                    OnPropertyChanged();
                }
            }
        }

        async Task Selected(Buildings buildings)
        {
            if (buildings == null)
                return;

            var route = $"{nameof(MyCoffeeDetailsPage)}?CoffeeId={buildings.Id}";
            await Shell.Current.GoToAsync(route);
        }

        async Task GetGrowtRequirements()
        {
            GrowtRequirements.Clear();
            var growtRequirement = await waoService.GetGrowtRequirements(selectedBuilding.Id);
            GrowtRequirements.AddRange(growtRequirement);
            DependencyService.Get<IToast>()?.MakeToast("Refreshed!");
        }
        async Task GetGrowtRequirementsLevel(int id, int level = 0)
        {
            GrowtRequirements.Clear();
            var growtRequirement = await waoService.GetGrowtRequirements(id, level);
            GrowtRequirements.AddRange(growtRequirement);
            DependencyService.Get<IToast>()?.MakeToast("Refreshed!");
        }
        async Task Refresh()
        {
            IsBusy = true;

#if DEBUG
            await Task.Delay(500);
#endif

            BuildingsColl.Clear();

            var buildings = await waoService.GetBuildings();

            BuildingsColl.AddRange(buildings);

            Levels.Clear();

            var levels = await waoService.GetBuildingLevels();

            Levels.AddRange(levels);

            IsBusy = false;

            DependencyService.Get<IToast>()?.MakeToast("Refreshed!");
        }
    }
}

