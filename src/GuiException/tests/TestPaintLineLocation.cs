﻿// ----------------------------------------------------------------
// ExceptionBrowser
// Version 1.0.0
// Copyright 2008, Irénée HOTTIER,
// 
// This is free software licensed under the NUnit license, You may
// obtain a copy of the license at http://nunit.org/?p=license&r=2.4
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.UiException;
using System.Drawing;
using NUnit.UiException.Controls;

namespace NUnit.UiException.Tests
{
    [TestFixture]
    public class TestPaintLineLocation
    {
        private PaintLineLocation _line;

        [SetUp]
        public void SetUp()
        {
            _line = new PaintLineLocation(42, "hello world!", new PointF(13, 42), true);
        }

        [Test]
        public void Test_PaintLineLocation()
        {
            Assert.That(_line.LineIndex, Is.EqualTo(42));
            Assert.That(_line.Text, Is.EqualTo("hello world!"));
            Assert.That(_line.Location, Is.EqualTo(new PointF(13, 42)));
            Assert.That(_line.IsHighlighted, Is.True);

            return;
        }       

        [Test]
        [ExpectedException(typeof(ArgumentNullException),
            ExpectedMessage = "text",
            MatchType = MessageMatch.Contains)]
        public void Test_SetText_Throws_NullTextException()
        {
            new PaintLineLocation(0, null, new PointF(0, 0), false); // throws exception
        }

        [Test]
        public void Test_Equals()
        {
            Assert.That(_line.Equals(null), Is.False);
            Assert.That(_line.Equals("hello"), Is.False);
            Assert.That(_line.Equals(new PaintLineLocation(0, "", new PointF(0, 0), false)), Is.False);

            Assert.That(
                _line.Equals(new PaintLineLocation(_line.LineIndex, _line.Text, _line.Location, !_line.IsHighlighted)),
                Is.False);
            Assert.That(
                _line.Equals(new PaintLineLocation(_line.LineIndex, _line.Text, new PointF(0, 0), _line.IsHighlighted)),
                Is.False);
            Assert.That(
                _line.Equals(new PaintLineLocation(_line.LineIndex, "", _line.Location, _line.IsHighlighted)),
                Is.False);
            Assert.That(
                _line.Equals(new PaintLineLocation(0, _line.Text, _line.Location, _line.IsHighlighted)),
                Is.False);

            Assert.That(_line.Equals(_line), Is.True);
            Assert.That(_line.Equals(
                new PaintLineLocation(_line.LineIndex, _line.Text, _line.Location, _line.IsHighlighted)),
                Is.True);

            return;
        }
    }
}