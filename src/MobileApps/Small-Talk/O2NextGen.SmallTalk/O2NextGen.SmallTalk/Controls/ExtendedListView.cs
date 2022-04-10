using O2NextGen.SmallTalk.Core.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;

namespace O2NextGen.SmallTalk.Core.Controls
{
    public class ExtendedListView : ListView
    {
        public ExtendedListView() : this(ListViewCachingStrategy.RecycleElement)
        {
        }

        public ExtendedListView(ListViewCachingStrategy cachingStrategy) : base(cachingStrategy)
        {
            //this.ItemAppearing += OnItemAppearing;
            this.PropertyChanged += ExtendedListView_PropertyChanged;
        }

        private void ExtendedListView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (this.BindingContext == null)
                return;
            var context = this.BindingContext as ChatDetailViewModel;
            if (context.Messages == null) return;
            //GET SCROLL CURRENT POSITION HERE!
            var target = context.Messages[context.Messages.Count - 1];

            ScrollTo(target, ScrollToPosition.End, true);
        }

        //private void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        //{
        //    if (ItemAppearingCommand != null)
        //    {
        //        ItemAppearingCommand?.Execute(e.Item);
        //    }
        //}
        public void ScrollToLast()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    if (ItemsSource != null && ItemsSource.Cast<object>().Count() > 0)
                    {
                        var msg = ItemsSource.Cast<object>().LastOrDefault();
                        if (msg != null)
                        {
                            ScrollTo(msg, ScrollToPosition.End, false);
                        }

                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }

            });
        }
    }
}
