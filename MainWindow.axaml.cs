using Avalonia.Controls;
using Avalonia.Threading;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForcePasswordCracker
{
    public partial class MainWindow : Window
    {
        private PasswordGenerator generator = new PasswordGenerator();
        private BruteForceEngine engine = new BruteForceEngine();
        private PerformanceLogger logger = new PerformanceLogger();

        private string targetHash = "";
        private CancellationTokenSource stopToken;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCreatePassword(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            generator.GeneratePassword();
            targetHash = generator.HashedPassword;
            PasswordText.Text = "Password: " + generator.PlainPassword;
            StatusText.Text = "Status: password created";
            ResultText.Text = "";
            TimeText.Text = "Elapsed: 0 ms";
        }

        private async void OnStart(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(targetHash))
            {
                StatusText.Text = "Status: create a password first";
                return;
            }

            StatusText.Text = "Status: cracking...";
            Progress.IsIndeterminate = true;
             Progress.Value = 100;
            stopToken = new CancellationTokenSource();

            string hashToCrack = targetHash;

            await Task.Run(() =>
            {
                var watch1 = Stopwatch.StartNew();
                string single = engine.CrackPassword(hashToCrack);
                watch1.Stop();

                var watch2 = Stopwatch.StartNew();
                string multi = engine.CrackPasswordParallel(hashToCrack);
                watch2.Stop();

                logger.Record(watch1.ElapsedMilliseconds, watch2.ElapsedMilliseconds);

                Dispatcher.UIThread.Post(() =>
                {
                    StatusText.Text = "Status: done";
                    Progress.IsIndeterminate = false;
                    TimeText.Text = $"Elapsed: single {watch1.ElapsedMilliseconds} ms, multi {watch2.ElapsedMilliseconds} ms";
                    ResultText.Text = "Found password: " + multi + "\n\n" + logger.GetReport();
                });
            });
        }

        private void OnStop(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (stopToken != null)
            {
                stopToken.Cancel();
            }
            StatusText.Text = "Status: stop requested";
        }

        private void OnClear(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            targetHash = "";
            PasswordText.Text = "Password: (none yet)";
            StatusText.Text = "Status: idle";
            Progress.IsIndeterminate = false;
             Progress.Value = 0;
            TimeText.Text = "Elapsed: 0 ms";
            ResultText.Text = "";
        }
    }
}