﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Numerics;
using Microsoft.UI.Private.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Windows.Foundation;
using Windows.UI;

namespace Microsoft.UI.Xaml.Controls;

internal partial class ScrollPresenterTestHooks
{
	private static ScrollPresenterTestHooks s_testHooks;

	public ScrollPresenterTestHooks()
	{
	}

	private static ScrollPresenterTestHooks EnsureGlobalTestHooks()
	{
		return s_testHooks ??= new ScrollPresenterTestHooks();
	}

	internal bool AreAnchorNotificationsRaised()
	{
		var hooks = EnsureGlobalTestHooks();
		return hooks.m_areAnchorNotificationsRaised;
	}

	internal void AreAnchorNotificationsRaised(bool areAnchorNotificationsRaised)
	{
		var hooks = EnsureGlobalTestHooks();
		hooks.m_areAnchorNotificationsRaised = areAnchorNotificationsRaised;
	}

	internal bool AreInteractionSourcesNotificationsRaised()
	{
		var hooks = EnsureGlobalTestHooks();
		return hooks.m_areInteractionSourcesNotificationsRaised;
	}

	internal void AreInteractionSourcesNotificationsRaised(bool areInteractionSourcesNotificationsRaised)
	{
		var hooks = EnsureGlobalTestHooks();
		hooks.m_areInteractionSourcesNotificationsRaised = areInteractionSourcesNotificationsRaised;
	}

	internal bool AreExpressionAnimationStatusNotificationsRaised()
	{
		var hooks = EnsureGlobalTestHooks();
		return hooks.m_areExpressionAnimationStatusNotificationsRaised;
	}

	void AreExpressionAnimationStatusNotificationsRaised(bool areExpressionAnimationStatusNotificationsRaised)
	{
		var hooks = EnsureGlobalTestHooks();
		hooks.m_areExpressionAnimationStatusNotificationsRaised = areExpressionAnimationStatusNotificationsRaised;
	}

	internal bool? IsAnimationsEnabledOverride()
	{
		var hooks = EnsureGlobalTestHooks();
		return hooks.m_isAnimationsEnabledOverride;
	}

	void IsAnimationsEnabledOverride(bool? isAnimationsEnabledOverride)
	{
		var hooks = EnsureGlobalTestHooks();
		hooks.m_isAnimationsEnabledOverride = isAnimationsEnabledOverride;
	}

	internal void GetOffsetsChangeVelocityParameters(out int millisecondsPerUnit, out int minMilliseconds, out int maxMilliseconds)
	{
		var hooks = EnsureGlobalTestHooks();
		millisecondsPerUnit = hooks.m_offsetsChangeMsPerUnit;
		minMilliseconds = hooks.m_offsetsChangeMinMs;
		maxMilliseconds = hooks.m_offsetsChangeMaxMs;
	}

	void SetOffsetsChangeVelocityParameters(int millisecondsPerUnit, int minMilliseconds, int maxMilliseconds)
	{
		var hooks = EnsureGlobalTestHooks();
		hooks.m_offsetsChangeMsPerUnit = millisecondsPerUnit;
		hooks.m_offsetsChangeMinMs = minMilliseconds;
		hooks.m_offsetsChangeMaxMs = maxMilliseconds;
	}

	internal void GetZoomFactorChangeVelocityParameters(out int millisecondsPerUnit, out int minMilliseconds, out int maxMilliseconds)
	{
		var hooks = EnsureGlobalTestHooks();
		millisecondsPerUnit = hooks.m_zoomFactorChangeMsPerUnit;
		minMilliseconds = hooks.m_zoomFactorChangeMinMs;
		maxMilliseconds = hooks.m_zoomFactorChangeMaxMs;
	}

	void SetZoomFactorChangeVelocityParameters(int millisecondsPerUnit, int minMilliseconds, int maxMilliseconds)
	{
		var hooks = EnsureGlobalTestHooks();
		hooks.m_zoomFactorChangeMsPerUnit = millisecondsPerUnit;
		hooks.m_zoomFactorChangeMinMs = minMilliseconds;
		hooks.m_zoomFactorChangeMaxMs = maxMilliseconds;
	}

	void GetContentLayoutOffsetX(ScrollPresenter scrollPresenter, out float contentLayoutOffsetX)
	{
		if (scrollPresenter is not null)
		{
			contentLayoutOffsetX = scrollPresenter.GetContentLayoutOffsetX();
		}
		else
		{
			contentLayoutOffsetX = 0.0f;
		}
	}

	void SetContentLayoutOffsetX(ScrollPresenter scrollPresenter, float contentLayoutOffsetX)
	{
		if (scrollPresenter is not null)
		{
			scrollPresenter.SetContentLayoutOffsetX(contentLayoutOffsetX);
		}
	}

	void GetContentLayoutOffsetY(ScrollPresenter scrollPresenter, out float contentLayoutOffsetY)
	{
		if (scrollPresenter is not null)
		{
			contentLayoutOffsetY = scrollPresenter.GetContentLayoutOffsetY();
		}
		else
		{
			contentLayoutOffsetY = 0.0f;
		}
	}

	void SetContentLayoutOffsetY(ScrollPresenter scrollPresenter, float contentLayoutOffsetY)
	{
		if (scrollPresenter is not null)
		{
			scrollPresenter.SetContentLayoutOffsetY(contentLayoutOffsetY);
		}
	}

	Vector2 GetArrangeRenderSizesDelta(ScrollPresenter scrollPresenter)
	{
		if (scrollPresenter is not null)
		{
			return scrollPresenter.GetArrangeRenderSizesDelta();
		}
		return new Vector2(0.0f, 0.0f);
	}

	Vector2 GetMinPosition(ScrollPresenter scrollPresenter)
	{
		if (scrollPresenter is not null)
		{
			return scrollPresenter.GetMinPosition();
		}
		return new Vector2(0.0f, 0.0f);
	}

	Vector2 GetMaxPosition(ScrollPresenter scrollPresenter)
	{
		if (scrollPresenter is not null)
		{
			return scrollPresenter.GetMaxPosition();
		}
		return new Vector2(0.0f, 0.0f);
	}

	ScrollPresenterViewChangeResult GetScrollCompletedResult(ScrollingScrollCompletedEventArgs scrollCompletedEventArgs)
	{
		if (scrollCompletedEventArgs is not null)
		{
			ScrollPresenterViewChangeResult result = scrollCompletedEventArgs.Result;
			return TestHooksViewChangeResult(result);
		}
		return ScrollPresenterViewChangeResult.Completed;
	}

	ScrollPresenterViewChangeResult GetZoomCompletedResult(ScrollingZoomCompletedEventArgs zoomCompletedEventArgs)
	{
		if (zoomCompletedEventArgs is not null)
		{
			ScrollPresenterViewChangeResult result = zoomCompletedEventArgs.Result;
			return TestHooksViewChangeResult(result);
		}
		return ScrollPresenterViewChangeResult.Completed;
	}

	internal void NotifyAnchorEvaluated(
		ScrollPresenter sender,
		UIElement anchorElement,
		double viewportAnchorPointHorizontalOffset,
		double viewportAnchorPointVerticalOffset)
	{
		var hooks = EnsureGlobalTestHooks();
		if (hooks.AnchorEvaluated is not null)
		{
			var anchorEvaluatedEventArgs = new ScrollPresenterTestHooksAnchorEvaluatedEventArgs(
				anchorElement, viewportAnchorPointHorizontalOffset, viewportAnchorPointVerticalOffset);

			hooks.AnchorEvaluated.Invoke(sender, anchorEvaluatedEventArgs);
		}
	}

	public event TypedEventHandler<ScrollPresenter, ScrollPresenterTestHooksAnchorEvaluatedEventArgs> AnchorEvaluated;

	internal void NotifyInteractionSourcesChanged(
			ScrollPresenter sender,
			Microsoft.UI.Composition.Interactions.CompositionInteractionSourceCollection interactionSources)
	{
		var hooks = EnsureGlobalTestHooks();
		if (hooks.InteractionSourcesChanged is not null)
		{
			var interactionSourcesChangedEventArgs = new ScrollPresenterTestHooksInteractionSourcesChangedEventArgs(
				interactionSources);

			hooks.InteractionSourcesChanged.Invoke(sender, interactionSourcesChangedEventArgs);
		}
	}

	public event TypedEventHandler<ScrollPresenter, ScrollPresenterTestHooksInteractionSourcesChangedEventArgs> InteractionSourcesChanged;

	internal void NotifyExpressionAnimationStatusChanged(
		ScrollPresenter sender,
		bool isExpressionAnimationStarted,
		string propertyName)
	{
		var hooks = EnsureGlobalTestHooks();
		if (hooks.ExpressionAnimationStatusChanged is not null)
		{
			var expressionAnimationStatusChangedEventArgs = new ScrollPresenterTestHooksExpressionAnimationStatusChangedEventArgs(
				isExpressionAnimationStarted, propertyName);

			hooks.ExpressionAnimationStatusChanged.Invoke(sender, expressionAnimationStatusChangedEventArgs);
		}
	}

	public event TypedEventHandler<ScrollPresenter, ScrollPresenterTestHooksExpressionAnimationStatusChangedEventArgs> ExpressionAnimationStatusChanged;

	internal void NotifyContentLayoutOffsetXChanged(ScrollPresenter sender)
	{
		var hooks = EnsureGlobalTestHooks();
		if (hooks.ContentLayoutOffsetXChanged is not null)
		{
			hooks.ContentLayoutOffsetXChanged.Invoke(sender, null);
		}
	}

	public event TypedEventHandler<ScrollPresenter, object> ContentLayoutOffsetXChanged;

	internal void NotifyContentLayoutOffsetYChanged(ScrollPresenter sender)
	{
		var hooks = EnsureGlobalTestHooks();
		if (hooks.ContentLayoutOffsetYChanged is not null)
		{
			hooks.ContentLayoutOffsetYChanged.Invoke(sender, null);
		}
	}

	public event TypedEventHandler<ScrollPresenter, object> ContentLayoutOffsetYChanged;

	IList<ScrollSnapPointBase> GetConsolidatedHorizontalScrollSnapPoints(ScrollPresenter scrollPresenter)
	{
		if (scrollPresenter is not null)
		{
			return scrollPresenter.GetConsolidatedHorizontalScrollSnapPoints();
		}
		else
		{
			return new List<ScrollSnapPointBase>();
		}
	}

	IList<ScrollSnapPointBase> GetConsolidatedVerticalScrollSnapPoints(ScrollPresenter scrollPresenter)
	{
		if (scrollPresenter is not null)
		{
			return scrollPresenter.GetConsolidatedVerticalScrollSnapPoints();
		}
		else
		{
			return new List<ScrollSnapPointBase>();
		}
	}

	IList<ZoomSnapPointBase> GetConsolidatedZoomSnapPoints(ScrollPresenter scrollPresenter)
	{
		if (scrollPresenter is not null)
		{
			return scrollPresenter.GetConsolidatedZoomSnapPoints();
		}
		else
		{
			return new List<ZoomSnapPointBase>();
		}
	}

	Vector2 GetHorizontalSnapPointActualApplicableZone(
		ScrollPresenter scrollPresenter,
		ScrollSnapPointBase scrollSnapPoint)
	{
		if (scrollSnapPoint is not null)
		{
			var snapPointWrapper = scrollPresenter.GetHorizontalSnapPointWrapper(scrollSnapPoint);
			var zone = snapPointWrapper.ActualApplicableZone();

			return new Vector2((float)zone.Item1, (float)zone.Item2);
		}
		else
		{
			return new Vector2(0.0f, 0.0f);
		}
	}

	Vector2 GetVerticalSnapPointActualApplicableZone(
		ScrollPresenter scrollPresenter,
		ScrollSnapPointBase scrollSnapPoint)
	{
		if (scrollSnapPoint is not null)
		{
			var snapPointWrapper = scrollPresenter.GetVerticalSnapPointWrapper(scrollSnapPoint);
			var zone = snapPointWrapper.ActualApplicableZone();

			return new Vector2((float)zone.Item1, (float)zone.Item2);
		}
		else
		{
			return new Vector2(0.0f, 0.0f);
		}
	}

	Vector2 GetZoomSnapPointActualApplicableZone(
		ScrollPresenter scrollPresenter,
		ZoomSnapPointBase zoomSnapPoint)
	{
		if (zoomSnapPoint is not null)
		{
			var snapPointWrapper = scrollPresenter.GetZoomSnapPointWrapper(zoomSnapPoint);
			var zone = snapPointWrapper.ActualApplicableZone();

			return new Vector2((float)zone.Item1, (float)zone.Item2);
		}
		else
		{
			return new Vector2(0.0f, 0.0f);
		}
	}

	int GetHorizontalSnapPointCombinationCount(
		ScrollPresenter scrollPresenter,
		ScrollSnapPointBase scrollSnapPoint)
	{
		if (scrollSnapPoint is not null)
		{
			var snapPointWrapper = scrollPresenter.GetHorizontalSnapPointWrapper(scrollSnapPoint);

			return snapPointWrapper.CombinationCount();
		}
		else
		{
			return 0;
		}
	}

	int GetVerticalSnapPointCombinationCount(
		ScrollPresenter scrollPresenter,
		ScrollSnapPointBase scrollSnapPoint)
	{
		if (scrollSnapPoint is not null)
		{
			var snapPointWrapper = scrollPresenter.GetVerticalSnapPointWrapper(scrollSnapPoint);

			return snapPointWrapper.CombinationCount();
		}
		else
		{
			return 0;
		}
	}

	int GetZoomSnapPointCombinationCount(
			ScrollPresenter scrollPresenter,
			ZoomSnapPointBase zoomSnapPoint)
	{
		if (zoomSnapPoint is not null)
		{
			var snapPointWrapper = scrollPresenter.GetZoomSnapPointWrapper(zoomSnapPoint);

			return snapPointWrapper.CombinationCount();
		}
		else
		{
			return 0;
		}
	}

	Color GetSnapPointVisualizationColor(SnapPointBase snapPoint)
	{

#if DEBUG
		if (snapPoint is not null)
		{
			return snapPoint.VisualizationColor;
		}
#endif // DBG
		return Colors.Black;
	}

	void SetSnapPointVisualizationColor(SnapPointBase snapPoint, Color color)
	{
#if DEBUG
		if (snapPoint is not null)
		{
			snapPoint.VisualizationColor = color;
		}
#endif // DBG
	}

	ScrollPresenterViewChangeResult TestHooksViewChangeResult(ScrollPresenterViewChangeResult result)
	{
		switch (result)
		{
			case ScrollPresenterViewChangeResult.Ignored:
				return ScrollPresenterViewChangeResult.Ignored;
			case ScrollPresenterViewChangeResult.Interrupted:
				return ScrollPresenterViewChangeResult.Interrupted;
			default:
				return ScrollPresenterViewChangeResult.Completed;
		}
	}
}
