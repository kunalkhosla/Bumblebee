﻿using Bumblebee.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Bumblebee.Implementation
{
    public class Clickable : Element, IClickable
    {
        public Clickable(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public Clickable(IBlock parent, IWebElement element)
            : base(parent, element)
        {
        }

        public virtual TResult Click<TResult>() where TResult : IBlock
        {
            Tag.Click();
            return Session.CurrentBlock<TResult>(ParentBlock.Tag);
        }

        public virtual TResult DoubleClick<TResult>() where TResult : IBlock
        {
            new Actions(Session.Driver).DoubleClick(Tag).Perform();
            return Session.CurrentBlock<TResult>(ParentBlock.Tag);
        }

        public virtual TResult ContextClick<TResult>() where TResult : IBlock
        {
            new Actions(Session.Driver).ContextClick(Tag).Perform();
            return Session.CurrentBlock<TResult>(ParentBlock.Tag);
        }
    }

    public class Clickable<TResult> : Clickable, IClickable<TResult> where TResult : IBlock
    {
        public Clickable(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public Clickable(IBlock parent, IWebElement element)
            : base(parent, element)
        {
        }

        public virtual TResult Click()
        {
            return Click<TResult>();
        }

        public virtual TResult DoubleClick()
        {
            return DoubleClick<TResult>();
        }

        public virtual TResult ContextClick()
        {
            return ContextClick<TResult>();
        }
    }
}
