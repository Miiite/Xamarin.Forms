﻿using Android.Support.V7.Widget;

namespace Xamarin.Forms.Platform.Android
{
	internal class GridLayoutSpanSizeLookup : GridLayoutManager.SpanSizeLookup
	{
		readonly GridItemsLayout _gridItemsLayout;
		readonly RecyclerView _recyclerView;

		public GridLayoutSpanSizeLookup(GridItemsLayout gridItemsLayout, RecyclerView recyclerView)
		{
			_gridItemsLayout = gridItemsLayout;
			_recyclerView = recyclerView;
		}

		public override int GetSpanSize(int position)
		{
			var itemViewType = _recyclerView.GetAdapter().GetItemViewType(position);

			if (itemViewType == ItemViewType.Header || itemViewType == ItemViewType.Footer)
			{
				return _gridItemsLayout.Span;
			}

			return 1;
		}
	}
}