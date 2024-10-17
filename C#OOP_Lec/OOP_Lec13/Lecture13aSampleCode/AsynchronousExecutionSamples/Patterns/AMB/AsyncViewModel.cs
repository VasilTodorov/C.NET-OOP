using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading;
using System.Windows;

namespace Patterns.AMB
{
    public class AsyncViewModel : DependencyObject
    {
        const string defaultQuery = "http://odata.netflix.com/Catalog/Titles?$inlinecount=allpages&$filter=ReleaseYear%20le%201942";

        #region Members

        CancelCommand cancel = null;
        FetchCommand fetch = null;
        NetflixQuery<Movie> query;
        CancellationTokenSource cancelSource;

        #endregion

        #region Dependency Properties

        public string Query
        {
            get { return (string)GetValue(QueryProperty); }
            set { SetValue(QueryProperty, value); }
        }

        public static readonly DependencyProperty QueryProperty =
            DependencyProperty.Register("Query", typeof(string), typeof(AsyncViewModel), new PropertyMetadata(defaultQuery));

        public ObservableCollection<Movie> Movies
        {
            get { return (ObservableCollection<Movie>)GetValue(MoviesProperty); }
            set { SetValue(MoviesProperty, value); }
        }

        public static readonly DependencyProperty MoviesProperty =
            DependencyProperty.Register("Movies", typeof(ObservableCollection<Movie>), typeof(AsyncViewModel), new PropertyMetadata(null));

        public double? Progress
        {
            get { return (double?)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        public static readonly DependencyProperty ProgressProperty =
            DependencyProperty.Register("Progress", typeof(double?), typeof(AsyncViewModel), new PropertyMetadata(0.0));

        public bool Fetching
        {
            get { return (bool)GetValue(FetchingProperty); }
            set { SetValue(FetchingProperty, value); }
        }

        public static readonly DependencyProperty FetchingProperty =
            DependencyProperty.Register("Fetching", typeof(bool), typeof(AsyncViewModel), new PropertyMetadata(
                new PropertyChangedCallback((d, e) =>
                {
                    var vm = (AsyncViewModel)d;
                    vm.Fetch.Invalidate();
                    vm.Cancel.Invalidate();
                })));

        public string ProgressText
        {
            get { return (string)GetValue(ProgressTextProperty); }
            set { SetValue(ProgressTextProperty, value); }
        }

        public static readonly DependencyProperty ProgressTextProperty =
            DependencyProperty.Register("ProgressText", typeof(string), typeof(AsyncViewModel), new PropertyMetadata(""));

        #endregion

        #region Commands

        public FetchCommand Fetch
        { 
            get { return fetch ?? (fetch = new FetchCommand(this)); } 
        }

        public CancelCommand Cancel
        { 
            get { return cancel ?? (cancel = new CancelCommand(this)); } 
        }

        #endregion Commands

        #region Async commands

        internal async void DoFetch()
        {
            Fetching = true;
            Progress = null;
            ProgressText = "Loading...";

            cancelSource = new CancellationTokenSource();
            query = new NetflixQuery<Movie>(Query);

            Movies = query.Entities;
            Movies.CollectionChanged += (s, ev) => 
            {
                if (query.EntitiesExpected != null)
                {
                    Progress = (double)Movies.Count / query.EntitiesExpected;
                    ProgressText = String.Format("Loaded {0} of {1} movies so far...", Movies.Count, query.EntitiesExpected);
                }
                else
                {
                    Progress = null;
                    ProgressText = String.Format("Loaded {0} movies so far...", Movies.Count, query.EntitiesExpected);
                }
            };

            try
            {
                await query.FetchEntitiesAsync(cancelSource.Token);
                ProgressText = String.Format("Loaded {0} movies.", Movies.Count);
            }
            catch (WebException)
            {
                ProgressText = String.Format("Cancelled after {0} movies.", Movies.Count);
            }
            catch (Exception e)
            {
                ProgressText = "Error!";
                MessageBox.Show(e.ToString());
            }

            Progress = 1.0;
            Fetching = false;
        }

        internal void DoCancel()
        {
            cancelSource.Cancel();
        }

        #endregion
    }
}
