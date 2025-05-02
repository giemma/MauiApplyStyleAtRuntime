using MauiApplyStyleAtRuntime.Resources.Styles.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApplyStyleAtRuntime.ViewModels
{
    public class MainPageViewModel
    {
        public Command SetTheme1 { get; set; }
        public Command SetTheme2 { get; set; }
        public Command SetTheme3 { get; set; }
        public Command SetTheme4 { get; set; }

        public MainPageViewModel()
        {
            SetTheme1 = new Command(() => {
                SetTheme(new Theme1());
            });

            SetTheme2 = new Command(() => {
                SetTheme(new Theme2());
            });

            SetTheme3 = new Command(() => {
                SetTheme(new Theme3());
            });

            SetTheme4 = new Command(() => {
                SetTheme(new Theme4());
            });
        }

        private void SetTheme(ThemeBase theme)
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries.ToList<ResourceDictionary>();

            var themesToDelete = mergedDictionaries.Where(x => x.GetType() == typeof(ThemeBase)).ToList();

            foreach (var themeToDelete in themesToDelete)
            {
                Application.Current.Resources.MergedDictionaries.Remove(themeToDelete);
            }

            Application.Current.Resources.MergedDictionaries.Add(theme);
        }
    }
}
