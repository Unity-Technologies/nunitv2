// ****************************************************************
// Copyright 2009, Charlie Poole
// This is free software licensed under the NUnit license. You may
// obtain a copy of the license at http://nunit.org
// ****************************************************************

using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine.Testing.Assertions.Constraints;

namespace UnityEngine.Testing.Assertions
{
    /// <summary>
    /// Delegate used by tests that execute code and
    /// capture any thrown exception.
    /// </summary>
    public delegate void TestDelegate();

    /// <summary>
    /// The Assert class contains a collection of static methods that
    /// implement the most common assertions used in NUnit.
    /// </summary>
    public class Assert
    {
        #region Constructor

        /// <summary>
        /// We don't actually want any instances of this object, but some people
        /// like to inherit from it to add other static methods. Hence, the
        /// protected constructor disallows any instances of this object. 
        /// </summary>
        protected Assert() { }

        #endregion

        #region Equals and ReferenceEquals

        /// <summary>
        /// The Equals method throws an AssertionException. This is done 
        /// to make sure there is no mistake by calling this function.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new bool Equals(object a, object b)
        {
            throw new InvalidOperationException("Assert.Equals should not be used for Assertions");
        }

        /// <summary>
        /// override the default ReferenceEquals to throw an AssertionException. This 
        /// implementation makes sure there is no mistake in calling this function 
        /// as part of Assert. 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static new void ReferenceEquals(object a, object b)
        {
            throw new InvalidOperationException("Assert.ReferenceEquals should not be used for Assertions");
        }

        #endregion

        #region Utility Asserts

        #region Pass

        /// <summary>
        /// Throws a <see cref="SuccessException"/> with the message and arguments 
        /// that are passed in. This allows a test to be cut short, with a result
        /// of success returned to NUnit.
        /// </summary>
        /// <param name="message">The message to initialize the <see cref="AssertionException"/> with.</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void Pass(string message, params object[] args)
        {
            if (message == null) message = string.Empty;
            else if (args != null && args.Length > 0)
                message = string.Format(message, args);

            throw new SuccessException(message);
        }

        /// <summary>
        /// Throws a <see cref="SuccessException"/> with the message and arguments 
        /// that are passed in. This allows a test to be cut short, with a result
        /// of success returned to NUnit.
        /// </summary>
        /// <param name="message">The message to initialize the <see cref="AssertionException"/> with.</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void Pass(string message)
        {
            Assert.Pass(message, null);
        }

        /// <summary>
        /// Throws a <see cref="SuccessException"/> with the message and arguments 
        /// that are passed in. This allows a test to be cut short, with a result
        /// of success returned to NUnit.
        /// </summary>
        [Conditional("UNITY_ASSERTIONS")]
        static public void Pass()
        {
            Assert.Pass(string.Empty, null);
        }

        #endregion

        #region Fail

        /// <summary>
        /// Throws an <see cref="AssertionException"/> with the message and arguments 
        /// that are passed in. This is used by the other Assert functions. 
        /// </summary>
        /// <param name="message">The message to initialize the <see cref="AssertionException"/> with.</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void Fail(string message, params object[] args)
        {
            if (message == null) message = string.Empty;
            else if (args != null && args.Length > 0)
                message = string.Format(message, args);

            throw new AssertionException(message);
        }

        /// <summary>
        /// Throws an <see cref="AssertionException"/> with the message that is 
        /// passed in. This is used by the other Assert functions. 
        /// </summary>
        /// <param name="message">The message to initialize the <see cref="AssertionException"/> with.</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void Fail(string message)
        {
            Assert.Fail(message, null);
        }

        /// <summary>
        /// Throws an <see cref="AssertionException"/>. 
        /// This is used by the other Assert functions. 
        /// </summary>
        [Conditional("UNITY_ASSERTIONS")]
        static public void Fail()
        {
            Assert.Fail(string.Empty, null);
        }

        #endregion

        #region Ignore

        /// <summary>
        /// Throws an <see cref="IgnoreException"/> with the message and arguments 
        /// that are passed in.  This causes the test to be reported as ignored.
        /// </summary>
        /// <param name="message">The message to initialize the <see cref="AssertionException"/> with.</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void Ignore(string message, params object[] args)
        {
            if (message == null) message = string.Empty;
            else if (args != null && args.Length > 0)
                message = string.Format(message, args);

            throw new IgnoreException(message);
        }

        /// <summary>
        /// Throws an <see cref="IgnoreException"/> with the message that is 
        /// passed in. This causes the test to be reported as ignored. 
        /// </summary>
        /// <param name="message">The message to initialize the <see cref="AssertionException"/> with.</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void Ignore(string message)
        {
            Assert.Ignore(message, null);
        }

        /// <summary>
        /// Throws an <see cref="IgnoreException"/>. 
        /// This causes the test to be reported as ignored. 
        /// </summary>
        [Conditional("UNITY_ASSERTIONS")]
        static public void Ignore()
        {
            Assert.Ignore(string.Empty, null);
        }

        #endregion

        #region InConclusive
        /// <summary>
        /// Throws an <see cref="InconclusiveException"/> with the message and arguments 
        /// that are passed in.  This causes the test to be reported as inconclusive.
        /// </summary>
        /// <param name="message">The message to initialize the <see cref="InconclusiveException"/> with.</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void Inconclusive(string message, params object[] args)
        {
            if (message == null) message = string.Empty;
            else if (args != null && args.Length > 0)
                message = string.Format(message, args);

            throw new InconclusiveException(message);
        }

        /// <summary>
        /// Throws an <see cref="InconclusiveException"/> with the message that is 
        /// passed in. This causes the test to be reported as inconclusive. 
        /// </summary>
        /// <param name="message">The message to initialize the <see cref="InconclusiveException"/> with.</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void Inconclusive(string message)
        {
            Assert.Inconclusive(message, null);
        }

        /// <summary>
        /// Throws an <see cref="InconclusiveException"/>. 
        /// This causes the test to be reported as Inconclusive. 
        /// </summary>
        [Conditional("UNITY_ASSERTIONS")]
        static public void Inconclusive()
        {
            Assert.Inconclusive(string.Empty, null);
        }

        #endregion

        #endregion

        #region Assert.That

        #region Object
        /// <summary>
        /// Apply a constraint to an actual value, succeeding if the constraint
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint to be applied</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That(object actual, IResolveConstraint expression)
        {
            Assert.That(actual, expression, null, null);
        }

        /// <summary>
        /// Apply a constraint to an actual value, succeeding if the constraint
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint to be applied</param>
        /// <param name="message">The message that will be displayed on failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That(object actual, IResolveConstraint expression, string message)
        {
            Assert.That(actual, expression, message, null);
        }

        /// <summary>
        /// Apply a constraint to an actual value, succeeding if the constraint
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint expression to be applied</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That(object actual, IResolveConstraint expression, string message, params object[] args)
        {
            Constraint constraint = expression.Resolve();

            IncrementAssertCount();
            if (!constraint.Matches(actual))
            {
                MessageWriter writer = new TextMessageWriter(message, args);
                constraint.WriteMessageTo(writer);
                throw new AssertionException(writer.ToString());
            }
        }
        #endregion

        #region Boolean
        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary> 
        /// <param name="condition">The evaluated condition</param>
        /// <param name="message">The message to display if the condition is false</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That(bool condition, string message, params object[] args)
        {
            Assert.That(condition, Is.True, message, args);
        }

        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary>
        /// <param name="condition">The evaluated condition</param>
        /// <param name="message">The message to display if the condition is false</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That(bool condition, string message)
        {
            Assert.That(condition, Is.True, message, null);
        }

        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary>
        /// <param name="condition">The evaluated condition</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That(bool condition)
        {
            Assert.That(condition, Is.True, null, null);
        }
        #endregion

        #region ref Boolean

#if !CLR_2_0 && !CLR_4_0
        /// <summary>
        /// Apply a constraint to a referenced boolean, succeeding if the constraint
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <param name="actual">The actual value to test</param>
        /// <param name="constraint">A Constraint to be applied</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That(ref bool actual, IResolveConstraint constraint)
        {
            Assert.That(ref actual, constraint.Resolve(), null, null);
        }

        /// <summary>
        /// Apply a constraint to a referenced value, succeeding if the constraint
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <param name="actual">The actual value to test</param>
        /// <param name="constraint">A Constraint to be applied</param>
        /// <param name="message">The message that will be displayed on failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That(ref bool actual, IResolveConstraint constraint, string message)
        {
            Assert.That(ref actual, constraint.Resolve(), message, null);
        }

        /// <summary>
        /// Apply a constraint to a referenced value, succeeding if the constraint
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint expression to be applied</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That(ref bool actual, IResolveConstraint expression, string message, params object[] args)
        {
            Constraint constraint = expression.Resolve();

            IncrementAssertCount();
            if (!constraint.Matches(ref actual))
            {
                MessageWriter writer = new TextMessageWriter(message, args);
                constraint.WriteMessageTo(writer);
                throw new AssertionException(writer.ToString());
            }
        }
#endif

        #endregion

        #region ActualValueDelegate

#if CLR_2_0 || CLR_4_0
        /// <summary>
		/// Apply a constraint to an actual value, succeeding if the constraint
		/// is satisfied and throwing an assertion exception on failure.
		/// </summary>
		/// <param name="del">An ActualValueDelegate returning the value to be tested</param>
        /// <param name="expr">A Constraint expression to be applied</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That<T>(ActualValueDelegate<T> del, IResolveConstraint expr)
		{
			Assert.That(del, expr.Resolve(), null, null);
		}

		/// <summary>
		/// Apply a constraint to an actual value, succeeding if the constraint
		/// is satisfied and throwing an assertion exception on failure.
		/// </summary>
		/// <param name="del">An ActualValueDelegate returning the value to be tested</param>
        /// <param name="expr">A Constraint expression to be applied</param>
        /// <param name="message">The message that will be displayed on failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That<T>(ActualValueDelegate<T> del, IResolveConstraint expr, string message)
		{
			Assert.That(del, expr.Resolve(), message, null);
		}

		/// <summary>
		/// Apply a constraint to an actual value, succeeding if the constraint
		/// is satisfied and throwing an assertion exception on failure.
		/// </summary>
		/// <param name="del">An ActualValueDelegate returning the value to be tested</param>
		/// <param name="expr">A Constraint expression to be applied</param>
		/// <param name="message">The message that will be displayed on failure</param>
		/// <param name="args">Arguments to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That<T>(ActualValueDelegate<T> del, IResolveConstraint expr, string message, params object[] args)
		{
			Constraint constraint = expr.Resolve();

			IncrementAssertCount();
			if (!constraint.Matches(del))
			{
				MessageWriter writer = new TextMessageWriter(message, args);
				constraint.WriteMessageTo(writer);
				throw new AssertionException(writer.ToString());
			}
		}
#else
        /// <summary>
        /// Apply a constraint to an actual value, succeeding if the constraint
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <param name="del">An ActualValueDelegate returning the value to be tested</param>
        /// <param name="expr">A Constraint expression to be applied</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That(ActualValueDelegate del, IResolveConstraint expr)
        {
            Assert.That(del, expr.Resolve(), null, null);
        }

        /// <summary>
        /// Apply a constraint to an actual value, succeeding if the constraint
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <param name="del">An ActualValueDelegate returning the value to be tested</param>
        /// <param name="expr">A Constraint expression to be applied</param>
        /// <param name="message">The message that will be displayed on failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That(ActualValueDelegate del, IResolveConstraint expr, string message)
        {
            Assert.That(del, expr.Resolve(), message, null);
        }

        /// <summary>
        /// Apply a constraint to an actual value, succeeding if the constraint
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <param name="del">An ActualValueDelegate returning the value to be tested</param>
        /// <param name="expr">A Constraint expression to be applied</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That(ActualValueDelegate del, IResolveConstraint expr, string message, params object[] args)
        {
            Constraint constraint = expr.Resolve();

            IncrementAssertCount();
            if (!constraint.Matches(del))
            {
                MessageWriter writer = new TextMessageWriter(message, args);
                constraint.WriteMessageTo(writer);
                throw new AssertionException(writer.ToString());
            }
        }
#endif

        #endregion

        #region ref Object

#if CLR_2_0 || CLR_4_0
        /// <summary>
        /// Apply a constraint to a referenced value, succeeding if the constraint
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint to be applied</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That<T>(ref T actual, IResolveConstraint expression)
        {
            Assert.That(ref actual, expression, null, null);
        }

        /// <summary>
        /// Apply a constraint to a referenced value, succeeding if the constraint
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint to be applied</param>
        /// <param name="message">The message that will be displayed on failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That<T>(ref T actual, IResolveConstraint expression, string message)
        {
            Assert.That(ref actual, expression, message, null);
        }

        /// <summary>
        /// Apply a constraint to a referenced value, succeeding if the constraint
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint to be applied</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That<T>(ref T actual, IResolveConstraint expression, string message, params object[] args)
        {
            Constraint constraint = expression.Resolve();

            IncrementAssertCount();
            if (!constraint.Matches(ref actual))
            {
                MessageWriter writer = new TextMessageWriter(message, args);
                constraint.WriteMessageTo(writer);
                throw new AssertionException(writer.ToString());
            }
        }
#endif
        #endregion

        #region TestDelegate

        /// <summary>
        /// Asserts that the code represented by a delegate throws an exception
        /// that satisfies the constraint provided.
        /// </summary>
        /// <param name="code">A TestDelegate to be executed</param>
        /// <param name="constraint">A ThrowsConstraint used in the test</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void That(TestDelegate code, IResolveConstraint constraint)
        {
            Assert.That((object)code, constraint);
        }

        #endregion

        #endregion

        #region Assert.ByVal
        /// <summary>
        /// Apply a constraint to an actual value, succeeding if the constraint
        /// is satisfied and throwing an assertion exception on failure.
        /// Used as a synonym for That in rare cases where a private setter 
        /// causes a Visual Basic compilation error.
        /// </summary>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint to be applied</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void ByVal(object actual, IResolveConstraint expression)
        {
            Assert.That(actual, expression, null, null);
        }

        /// <summary>
        /// Apply a constraint to an actual value, succeeding if the constraint
        /// is satisfied and throwing an assertion exception on failure.
        /// Used as a synonym for That in rare cases where a private setter 
        /// causes a Visual Basic compilation error.
        /// </summary>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint to be applied</param>
        /// <param name="message">The message that will be displayed on failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void ByVal(object actual, IResolveConstraint expression, string message)
        {
            Assert.That(actual, expression, message, null);
        }

        /// <summary>
        /// Apply a constraint to an actual value, succeeding if the constraint
        /// is satisfied and throwing an assertion exception on failure. 
        /// Used as a synonym for That in rare cases where a private setter 
        /// causes a Visual Basic compilation error.
        /// </summary>
        /// <remarks>
        /// This method is provided for use by VB developers needing to test
        /// the value of properties with private setters.
        /// </remarks>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint expression to be applied</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        static public void ByVal(object actual, IResolveConstraint expression, string message, params object[] args)
        {
            Assert.That(actual, expression, message, args);
        }
        #endregion

        #region DoesNotThrow

        /// <summary>
        /// Verifies that a delegate does not throw an exception
        /// </summary>
        /// <param name="code">A TestDelegate</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void DoesNotThrow(TestDelegate code, string message, params object[] args)
        {
            Assert.That(code, new ThrowsNothingConstraint(), message, args);
        }

        /// <summary>
        /// Verifies that a delegate does not throw an exception.
        /// </summary>
        /// <param name="code">A TestDelegate</param>
        /// <param name="message">The message that will be displayed on failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void DoesNotThrow(TestDelegate code, string message)
        {
            DoesNotThrow(code, message, null);
        }

        /// <summary>
        /// Verifies that a delegate does not throw an exception.
        /// </summary>
        /// <param name="code">A TestDelegate</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void DoesNotThrow(TestDelegate code)
        {
            DoesNotThrow(code, string.Empty, null);
        }

        #endregion

        #region True

        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary>
        /// <param name="condition">The evaluated condition</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void True(bool condition, string message, params object[] args)
        {
            Assert.That(condition, Is.True, message, args);
        }
        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary>
        /// <param name="condition">The evaluated condition</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void True(bool condition, string message)
        {
            Assert.That(condition, Is.True, message, null);
        }
        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary>
        /// <param name="condition">The evaluated condition</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void True(bool condition)
        {
            Assert.That(condition, Is.True, null, null);
        }

        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary>
        /// <param name="condition">The evaluated condition</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsTrue(bool condition, string message, params object[] args)
        {
            Assert.That(condition, Is.True, message, args);
        }
        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary>
        /// <param name="condition">The evaluated condition</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsTrue(bool condition, string message)
        {
            Assert.That(condition, Is.True, message, null);
        }
        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary>
        /// <param name="condition">The evaluated condition</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsTrue(bool condition)
        {
            Assert.That(condition, Is.True, null, null);
        }

        #endregion

        #region False

        /// <summary>
        /// Asserts that a condition is false. If the condition is true the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary> 
        /// <param name="condition">The evaluated condition</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void False(bool condition, string message, params object[] args)
        {
            Assert.That(condition, Is.False, message, args);
        }
        /// <summary>
        /// Asserts that a condition is false. If the condition is true the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary> 
        /// <param name="condition">The evaluated condition</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void False(bool condition, string message)
        {
            Assert.That(condition, Is.False, message, null);
        }
        /// <summary>
        /// Asserts that a condition is false. If the condition is true the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary> 
        /// <param name="condition">The evaluated condition</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void False(bool condition)
        {
            Assert.That(condition, Is.False, null, null);
        }

        /// <summary>
        /// Asserts that a condition is false. If the condition is true the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary> 
        /// <param name="condition">The evaluated condition</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsFalse(bool condition, string message, params object[] args)
        {
            Assert.That(condition, Is.False, message, args);
        }
        /// <summary>
        /// Asserts that a condition is false. If the condition is true the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary> 
        /// <param name="condition">The evaluated condition</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsFalse(bool condition, string message)
        {
            Assert.That(condition, Is.False, message, null);
        }
        /// <summary>
        /// Asserts that a condition is false. If the condition is true the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary> 
        /// <param name="condition">The evaluated condition</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsFalse(bool condition)
        {
            Assert.That(condition, Is.False, null, null);
        }

        #endregion

        #region NotNull

        /// <summary>
        /// Verifies that the object that is passed in is not equal to <code>null</code>
        /// If the object is <code>null</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void NotNull(object anObject, string message, params object[] args)
        {
            Assert.That(anObject, Is.Not.Null, message, args);
        }
        /// <summary>
        /// Verifies that the object that is passed in is not equal to <code>null</code>
        /// If the object is <code>null</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void NotNull(object anObject, string message)
        {
            Assert.That(anObject, Is.Not.Null, message, null);
        }
        /// <summary>
        /// Verifies that the object that is passed in is not equal to <code>null</code>
        /// If the object is <code>null</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void NotNull(object anObject)
        {
            Assert.That(anObject, Is.Not.Null, null, null);
        }

        /// <summary>
        /// Verifies that the object that is passed in is not equal to <code>null</code>
        /// If the object is <code>null</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotNull(object anObject, string message, params object[] args)
        {
            Assert.That(anObject, Is.Not.Null, message, args);
        }
        /// <summary>
        /// Verifies that the object that is passed in is not equal to <code>null</code>
        /// If the object is <code>null</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotNull(object anObject, string message)
        {
            Assert.That(anObject, Is.Not.Null, message, null);
        }
        /// <summary>
        /// Verifies that the object that is passed in is not equal to <code>null</code>
        /// If the object is <code>null</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotNull(object anObject)
        {
            Assert.That(anObject, Is.Not.Null, null, null);
        }

        #endregion

        #region Null

        /// <summary>
        /// Verifies that the object that is passed in is equal to <code>null</code>
        /// If the object is not <code>null</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Null(object anObject, string message, params object[] args)
        {
            Assert.That(anObject, Is.Null, message, args);
        }
        /// <summary>
        /// Verifies that the object that is passed in is equal to <code>null</code>
        /// If the object is not <code>null</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Null(object anObject, string message)
        {
            Assert.That(anObject, Is.Null, message, null);
        }
        /// <summary>
        /// Verifies that the object that is passed in is equal to <code>null</code>
        /// If the object is not <code>null</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Null(object anObject)
        {
            Assert.That(anObject, Is.Null, null, null);
        }

        /// <summary>
        /// Verifies that the object that is passed in is equal to <code>null</code>
        /// If the object is not <code>null</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNull(object anObject, string message, params object[] args)
        {
            Assert.That(anObject, Is.Null, message, args);
        }
        /// <summary>
        /// Verifies that the object that is passed in is equal to <code>null</code>
        /// If the object is not <code>null</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNull(object anObject, string message)
        {
            Assert.That(anObject, Is.Null, message, null);
        }
        /// <summary>
        /// Verifies that the object that is passed in is equal to <code>null</code>
        /// If the object is not <code>null</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNull(object anObject)
        {
            Assert.That(anObject, Is.Null, null, null);
        }

        #endregion

        #region AreEqual

        #region Ints

        /// <summary>
        /// Verifies that two ints are equal. If they are not, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(int expected, int actual, string message, params object[] args)
        {
            Assert.That(actual, Is.EqualTo(expected), message, args);
        }
        /// <summary>
        /// Verifies that two ints are equal. If they are not, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(int expected, int actual, string message)
        {
            Assert.That(actual, Is.EqualTo(expected), message, null);
        }
        /// <summary>
        /// Verifies that two ints are equal. If they are not, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(int expected, int actual)
        {
            Assert.That(actual, Is.EqualTo(expected), null, null);
        }

        #endregion

        #region Longs

        /// <summary>
        /// Verifies that two longs are equal. If they are not, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(long expected, long actual, string message, params object[] args)
        {
            Assert.That(actual, Is.EqualTo(expected), message, args);
        }
        /// <summary>
        /// Verifies that two longs are equal. If they are not, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(long expected, long actual, string message)
        {
            Assert.That(actual, Is.EqualTo(expected), message, null);
        }
        /// <summary>
        /// Verifies that two longs are equal. If they are not, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(long expected, long actual)
        {
            Assert.That(actual, Is.EqualTo(expected), null, null);
        }

        #endregion

        #region Unsigned Ints

        /// <summary>
        /// Verifies that two unsigned ints are equal. If they are not, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(uint expected, uint actual, string message, params object[] args)
        {
            Assert.That(actual, Is.EqualTo(expected), message, args);
        }
        /// <summary>
        /// Verifies that two unsigned ints are equal. If they are not, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(uint expected, uint actual, string message)
        {
            Assert.That(actual, Is.EqualTo(expected), message, null);
        }
        /// <summary>
        /// Verifies that two unsigned ints are equal. If they are not, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(uint expected, uint actual)
        {
            Assert.That(actual, Is.EqualTo(expected), null, null);
        }

        #endregion

        #region Unsigned Longs

        /// <summary>
        /// Verifies that two unsigned longs are equal. If they are not, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(ulong expected, ulong actual, string message, params object[] args)
        {
            Assert.That(actual, Is.EqualTo(expected), message, args);
        }
        /// <summary>
        /// Verifies that two unsigned longs are equal. If they are not, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(ulong expected, ulong actual, string message)
        {
            Assert.That(actual, Is.EqualTo(expected), message, null);
        }
        /// <summary>
        /// Verifies that two unsigned longs are equal. If they are not, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(ulong expected, ulong actual)
        {
            Assert.That(actual, Is.EqualTo(expected), null, null);
        }

        #endregion

        #region Decimals

        /// <summary>
        /// Verifies that two decimals are equal. If they are not, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(decimal expected, decimal actual, string message, params object[] args)
        {
            Assert.That(actual, Is.EqualTo(expected), message, args);
        }
        /// <summary>
        /// Verifies that two decimals are equal. If they are not, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(decimal expected, decimal actual, string message)
        {
            Assert.That(actual, Is.EqualTo(expected), message, null);
        }
        /// <summary>
        /// Verifies that two decimals are equal. If they are not, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(decimal expected, decimal actual)
        {
            Assert.That(actual, Is.EqualTo(expected), null, null);
        }

        #endregion

        #region Doubles

        /// <summary>
        /// Verifies that two doubles are equal considering a delta. If the
        /// expected value is infinity then the delta value is ignored. If 
        /// they are not equal then an <see cref="AssertionException"/> is
        /// thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="delta">The maximum acceptable difference between the
        /// the expected and the actual</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(double expected, double actual, double delta, string message, params object[] args)
        {
            AssertDoublesAreEqual(expected, actual, delta, message, args);
        }
        /// <summary>
        /// Verifies that two doubles are equal considering a delta. If the
        /// expected value is infinity then the delta value is ignored. If 
        /// they are not equal then an <see cref="AssertionException"/> is
        /// thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="delta">The maximum acceptable difference between the
        /// the expected and the actual</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(double expected, double actual, double delta, string message)
        {
            AssertDoublesAreEqual(expected, actual, delta, message, null);
        }
        /// <summary>
        /// Verifies that two doubles are equal considering a delta. If the
        /// expected value is infinity then the delta value is ignored. If 
        /// they are not equal then an <see cref="AssertionException"/> is
        /// thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="delta">The maximum acceptable difference between the
        /// the expected and the actual</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(double expected, double actual, double delta)
        {
            AssertDoublesAreEqual(expected, actual, delta, null, null);
        }

#if CLR_2_0 || CLR_4_0
        /// <summary>
        /// Verifies that two doubles are equal considering a delta. If the
        /// expected value is infinity then the delta value is ignored. If 
        /// they are not equal then an <see cref="AssertionException"/> is
        /// thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="delta">The maximum acceptable difference between the
        /// the expected and the actual</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(double expected, double? actual, double delta, string message, params object[] args)
        {
            AssertDoublesAreEqual(expected, (double)actual, delta, message, args);
        }
        /// <summary>
        /// Verifies that two doubles are equal considering a delta. If the
        /// expected value is infinity then the delta value is ignored. If 
        /// they are not equal then an <see cref="AssertionException"/> is
        /// thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="delta">The maximum acceptable difference between the
        /// the expected and the actual</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(double expected, double? actual, double delta, string message)
        {
            AssertDoublesAreEqual(expected, (double)actual, delta, message, null);
        }
        /// <summary>
        /// Verifies that two doubles are equal considering a delta. If the
        /// expected value is infinity then the delta value is ignored. If 
        /// they are not equal then an <see cref="AssertionException"/> is
        /// thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="delta">The maximum acceptable difference between the
        /// the expected and the actual</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(double expected, double? actual, double delta)
        {
            AssertDoublesAreEqual(expected, (double)actual, delta, null, null);
        }
#endif

        #endregion

        #region Objects

        /// <summary>
        /// Verifies that two objects are equal.  Two objects are considered
        /// equal if both are null, or if both have the same value. NUnit
        /// has special semantics for some object types.
        /// If they are not equal an <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The value that is expected</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(object expected, object actual, string message, params object[] args)
        {
            Assert.That(actual, Is.EqualTo(expected), message, args);
        }
        /// <summary>
        /// Verifies that two objects are equal.  Two objects are considered
        /// equal if both are null, or if both have the same value. NUnit
        /// has special semantics for some object types.
        /// If they are not equal an <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The value that is expected</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(object expected, object actual, string message)
        {
            Assert.That(actual, Is.EqualTo(expected), message, null);
        }
        /// <summary>
        /// Verifies that two objects are equal.  Two objects are considered
        /// equal if both are null, or if both have the same value. NUnit
        /// has special semantics for some object types.
        /// If they are not equal an <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The value that is expected</param>
        /// <param name="actual">The actual value</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(object expected, object actual)
        {
            Assert.That(actual, Is.EqualTo(expected), null, null);
        }

        #endregion

        #endregion

        #region AreNotEqual

        #region Ints

        /// <summary>
        /// Verifies that two ints are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(int expected, int actual, string message, params object[] args)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message, args);
        }
        /// <summary>
        /// Verifies that two ints are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(int expected, int actual, string message)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message, null);
        }
        /// <summary>
        /// Verifies that two ints are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(int expected, int actual)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), null, null);
        }

        #endregion

        #region Longs

        /// <summary>
        /// Verifies that two longs are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(long expected, long actual, string message, params object[] args)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message, args);
        }
        /// <summary>
        /// Verifies that two longs are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(long expected, long actual, string message)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message, null);
        }
        /// <summary>
        /// Verifies that two longs are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(long expected, long actual)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), null, null);
        }

        #endregion

        #region Unsigned Ints

        /// <summary>
        /// Verifies that two unsigned ints are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(uint expected, uint actual, string message, params object[] args)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message, args);
        }
        /// <summary>
        /// Verifies that two unsigned ints are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(uint expected, uint actual, string message)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message, null);
        }
        /// <summary>
        /// Verifies that two unsigned ints are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(uint expected, uint actual)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), null, null);
        }

        #endregion

        #region Unsigned Longs

        /// <summary>
        /// Verifies that two unsigned longs are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(ulong expected, ulong actual, string message, params object[] args)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message, args);
        }
        /// <summary>
        /// Verifies that two unsigned longs are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(ulong expected, ulong actual, string message)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message, null);
        }
        /// <summary>
        /// Verifies that two unsigned longs are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(ulong expected, ulong actual)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), null, null);
        }

        #endregion

        #region Decimals

        /// <summary>
        /// Verifies that two decimals are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(decimal expected, decimal actual, string message, params object[] args)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message, args);
        }
        /// <summary>
        /// Verifies that two decimals are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(decimal expected, decimal actual, string message)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message, null);
        }
        /// <summary>
        /// Verifies that two decimals are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(decimal expected, decimal actual)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), null, null);
        }

        #endregion

        #region Floats

        /// <summary>
        /// Verifies that two floats are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(float expected, float actual, string message, params object[] args)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message, args);
        }
        /// <summary>
        /// Verifies that two floats are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(float expected, float actual, string message)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message, null);
        }
        /// <summary>
        /// Verifies that two floats are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(float expected, float actual)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), null, null);
        }

        #endregion

        #region Doubles

        /// <summary>
        /// Verifies that two doubles are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(double expected, double actual, string message, params object[] args)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message, args);
        }
        /// <summary>
        /// Verifies that two doubles are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(double expected, double actual, string message)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message, null);
        }
        /// <summary>
        /// Verifies that two doubles are not equal. If they are equal, then an 
        /// <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(double expected, double actual)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), null, null);
        }

        #endregion

        #region Objects

        /// <summary>
        /// Verifies that two objects are not equal.  Two objects are considered
        /// equal if both are null, or if both have the same value. NUnit
        /// has special semantics for some object types.
        /// If they are equal an <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The value that is expected</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(object expected, object actual, string message, params object[] args)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message, args);
        }
        /// <summary>
        /// Verifies that two objects are not equal.  Two objects are considered
        /// equal if both are null, or if both have the same value. NUnit
        /// has special semantics for some object types.
        /// If they are equal an <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The value that is expected</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(object expected, object actual, string message)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message, null);
        }
        /// <summary>
        /// Verifies that two objects are not equal.  Two objects are considered
        /// equal if both are null, or if both have the same value. NUnit
        /// has special semantics for some object types.
        /// If they are equal an <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The value that is expected</param>
        /// <param name="actual">The actual value</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(object expected, object actual)
        {
            Assert.That(actual, Is.Not.EqualTo(expected), null, null);
        }

        #endregion

        #endregion

        #region AreSame

        /// <summary>
        /// Asserts that two objects refer to the same object. If they
        /// are not the same an <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The actual object</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreSame(object expected, object actual, string message, params object[] args)
        {
            Assert.That(actual, Is.SameAs(expected), message, args);
        }
        /// <summary>
        /// Asserts that two objects refer to the same object. If they
        /// are not the same an <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The actual object</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreSame(object expected, object actual, string message)
        {
            Assert.That(actual, Is.SameAs(expected), message, null);
        }
        /// <summary>
        /// Asserts that two objects refer to the same object. If they
        /// are not the same an <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The actual object</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreSame(object expected, object actual)
        {
            Assert.That(actual, Is.SameAs(expected), null, null);
        }

        #endregion

        #region AreNotSame

        /// <summary>
        /// Asserts that two objects do not refer to the same object. If they
        /// are the same an <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The actual object</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotSame(object expected, object actual, string message, params object[] args)
        {
            Assert.That(actual, Is.Not.SameAs(expected), message, args);
        }
        /// <summary>
        /// Asserts that two objects do not refer to the same object. If they
        /// are the same an <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The actual object</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotSame(object expected, object actual, string message)
        {
            Assert.That(actual, Is.Not.SameAs(expected), message, null);
        }
        /// <summary>
        /// Asserts that two objects do not refer to the same object. If they
        /// are the same an <see cref="AssertionException"/> is thrown.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The actual object</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotSame(object expected, object actual)
        {
            Assert.That(actual, Is.Not.SameAs(expected), null, null);
        }

        #endregion

        #region IsNaN

        /// <summary>
        /// Verifies that the double that is passed in is an <code>NaN</code> value.
        /// If the object is not <code>NaN</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="aDouble">The value that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNaN(double aDouble, string message, params object[] args)
        {
            Assert.That(aDouble, Is.NaN, message, args);
        }
        /// <summary>
        /// Verifies that the double that is passed in is an <code>NaN</code> value.
        /// If the object is not <code>NaN</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="aDouble">The value that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNaN(double aDouble, string message)
        {
            Assert.That(aDouble, Is.NaN, message, null);
        }
        /// <summary>
        /// Verifies that the double that is passed in is an <code>NaN</code> value.
        /// If the object is not <code>NaN</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="aDouble">The value that is to be tested</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNaN(double aDouble)
        {
            Assert.That(aDouble, Is.NaN, null, null);
        }

#if CLR_2_0 || CLR_4_0
        /// <summary>
        /// Verifies that the double that is passed in is an <code>NaN</code> value.
        /// If the object is not <code>NaN</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="aDouble">The value that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNaN(double? aDouble, string message, params object[] args)
        {
            Assert.That(aDouble, Is.NaN, message, args);
        }
        /// <summary>
        /// Verifies that the double that is passed in is an <code>NaN</code> value.
        /// If the object is not <code>NaN</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="aDouble">The value that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNaN(double? aDouble, string message)
        {
            Assert.That(aDouble, Is.NaN, message, null);
        }
        /// <summary>
        /// Verifies that the double that is passed in is an <code>NaN</code> value.
        /// If the object is not <code>NaN</code> then an <see cref="AssertionException"/>
        /// is thrown.
        /// </summary>
        /// <param name="aDouble">The value that is to be tested</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNaN(double? aDouble)
        {
            Assert.That(aDouble, Is.NaN, null, null);
        }
#endif

        #endregion

        #region IsEmpty

        /// <summary>
        /// Assert that a string is empty - that is equal to string.Empty
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsEmpty(string aString, string message, params object[] args)
        {
            Assert.That(aString, new EmptyStringConstraint(), message, args);
        }
        /// <summary>
        /// Assert that a string is empty - that is equal to string.Empty
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsEmpty(string aString, string message)
        {
            Assert.That(aString, new EmptyStringConstraint(), message, null);
        }
        /// <summary>
        /// Assert that a string is empty - that is equal to string.Empty
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsEmpty(string aString)
        {
            Assert.That(aString, new EmptyStringConstraint(), null, null);
        }

        #endregion

        #region IsEmpty

        /// <summary>
        /// Assert that an array, list or other collection is empty
        /// </summary>
        /// <param name="collection">An array, list or other collection implementing ICollection</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsEmpty(IEnumerable collection, string message, params object[] args)
        {
            Assert.That(collection, new EmptyCollectionConstraint(), message, args);
        }
        /// <summary>
        /// Assert that an array, list or other collection is empty
        /// </summary>
        /// <param name="collection">An array, list or other collection implementing ICollection</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsEmpty(IEnumerable collection, string message)
        {
            Assert.That(collection, new EmptyCollectionConstraint(), message, null);
        }
        /// <summary>
        /// Assert that an array, list or other collection is empty
        /// </summary>
        /// <param name="collection">An array, list or other collection implementing ICollection</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsEmpty(IEnumerable collection)
        {
            Assert.That(collection, new EmptyCollectionConstraint(), null, null);
        }

        #endregion

        #region IsNotEmpty

        /// <summary>
        /// Assert that a string is not empty - that is not equal to string.Empty
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotEmpty(string aString, string message, params object[] args)
        {
            Assert.That(aString, Is.Not.Empty, message, args);
        }
        /// <summary>
        /// Assert that a string is not empty - that is not equal to string.Empty
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotEmpty(string aString, string message)
        {
            Assert.That(aString, Is.Not.Empty, message, null);
        }
        /// <summary>
        /// Assert that a string is not empty - that is not equal to string.Empty
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotEmpty(string aString)
        {
            Assert.That(aString, Is.Not.Empty, null, null);
        }

        #endregion

        #region IsNotEmpty

        /// <summary>
        /// Assert that an array, list or other collection is not empty
        /// </summary>
        /// <param name="collection">An array, list or other collection implementing ICollection</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotEmpty(IEnumerable collection, string message, params object[] args)
        {
            Assert.That(collection, Is.Not.Empty, message, args);
        }
        /// <summary>
        /// Assert that an array, list or other collection is not empty
        /// </summary>
        /// <param name="collection">An array, list or other collection implementing ICollection</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotEmpty(IEnumerable collection, string message)
        {
            Assert.That(collection, Is.Not.Empty, message, null);
        }
        /// <summary>
        /// Assert that an array, list or other collection is not empty
        /// </summary>
        /// <param name="collection">An array, list or other collection implementing ICollection</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotEmpty(IEnumerable collection)
        {
            Assert.That(collection, Is.Not.Empty, null, null);
        }

        #endregion

        #region IsNullOrEmpty

        /// <summary>
        /// Assert that a string is either null or equal to string.Empty
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNullOrEmpty(string aString, string message, params object[] args)
        {
            Assert.That(aString, new NullOrEmptyStringConstraint(), message, args);
        }
        /// <summary>
        /// Assert that a string is either null or equal to string.Empty
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNullOrEmpty(string aString, string message)
        {
            Assert.That(aString, new NullOrEmptyStringConstraint(), message, null);
        }
        /// <summary>
        /// Assert that a string is either null or equal to string.Empty
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNullOrEmpty(string aString)
        {
            Assert.That(aString, new NullOrEmptyStringConstraint(), null, null);
        }

        #endregion

        #region IsNotNullOrEmpty

        /// <summary>
        /// Assert that a string is not null or empty
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotNullOrEmpty(string aString, string message, params object[] args)
        {
            Assert.That(aString, new NotConstraint(new NullOrEmptyStringConstraint()), message, args);
        }
        /// <summary>
        /// Assert that a string is not null or empty
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotNullOrEmpty(string aString, string message)
        {
            Assert.That(aString, new NotConstraint(new NullOrEmptyStringConstraint()), message, null);
        }
        /// <summary>
        /// Assert that a string is not null or empty
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotNullOrEmpty(string aString)
        {
            Assert.That(aString, new NotConstraint(new NullOrEmptyStringConstraint()), null, null);
        }

        #endregion

        #region IsAssignableFrom

        /// <summary>
        /// Asserts that an object may be assigned a  value of a given Type.
        /// </summary>
        /// <param name="expected">The expected Type.</param>
        /// <param name="actual">The object under examination</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsAssignableFrom(Type expected, object actual, string message, params object[] args)
        {
            Assert.That(actual, Is.AssignableFrom(expected), message, args);
        }
        /// <summary>
        /// Asserts that an object may be assigned a  value of a given Type.
        /// </summary>
        /// <param name="expected">The expected Type.</param>
        /// <param name="actual">The object under examination</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsAssignableFrom(Type expected, object actual, string message)
        {
            Assert.That(actual, Is.AssignableFrom(expected), message, null);
        }
        /// <summary>
        /// Asserts that an object may be assigned a  value of a given Type.
        /// </summary>
        /// <param name="expected">The expected Type.</param>
        /// <param name="actual">The object under examination</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsAssignableFrom(Type expected, object actual)
        {
            Assert.That(actual, Is.AssignableFrom(expected), null, null);
        }

        #endregion

        #region IsAssignableFrom<T>

#if CLR_2_0 || CLR_4_0
        /// <summary>
        /// Asserts that an object may be assigned a  value of a given Type.
        /// </summary>
        /// <typeparam name="T">The expected Type.</typeparam>
        /// <param name="actual">The object under examination</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsAssignableFrom<T>(object actual, string message, params object[] args)
        {
            Assert.That(actual, Is.AssignableFrom(typeof(T)), message, args);
        }
        /// <summary>
        /// Asserts that an object may be assigned a  value of a given Type.
        /// </summary>
        /// <typeparam name="T">The expected Type.</typeparam>
        /// <param name="actual">The object under examination</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsAssignableFrom<T>(object actual, string message)
        {
            Assert.That(actual, Is.AssignableFrom(typeof(T)), message, null);
        }
        /// <summary>
        /// Asserts that an object may be assigned a  value of a given Type.
        /// </summary>
        /// <typeparam name="T">The expected Type.</typeparam>
        /// <param name="actual">The object under examination</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsAssignableFrom<T>(object actual)
        {
            Assert.That(actual, Is.AssignableFrom(typeof(T)), null, null);
        }
#endif

        #endregion

        #region IsNotAssignableFrom

        /// <summary>
        /// Asserts that an object may not be assigned a  value of a given Type.
        /// </summary>
        /// <param name="expected">The expected Type.</param>
        /// <param name="actual">The object under examination</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotAssignableFrom(Type expected, object actual, string message, params object[] args)
        {
            Assert.That(actual, Is.Not.AssignableFrom(expected), message, args);
        }
        /// <summary>
        /// Asserts that an object may not be assigned a  value of a given Type.
        /// </summary>
        /// <param name="expected">The expected Type.</param>
        /// <param name="actual">The object under examination</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotAssignableFrom(Type expected, object actual, string message)
        {
            Assert.That(actual, Is.Not.AssignableFrom(expected), message, null);
        }
        /// <summary>
        /// Asserts that an object may not be assigned a  value of a given Type.
        /// </summary>
        /// <param name="expected">The expected Type.</param>
        /// <param name="actual">The object under examination</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotAssignableFrom(Type expected, object actual)
        {
            Assert.That(actual, Is.Not.AssignableFrom(expected), null, null);
        }

        #endregion

        #region IsNotAssignableFrom<T>

#if CLR_2_0 || CLR_4_0
        /// <summary>
        /// Asserts that an object may not be assigned a  value of a given Type.
        /// </summary>
        /// <typeparam name="T">The expected Type.</typeparam>
        /// <param name="actual">The object under examination</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotAssignableFrom<T>(object actual, string message, params object[] args)
        {
            Assert.That(actual, Is.Not.AssignableFrom(typeof(T)), message, args);
        }
        /// <summary>
        /// Asserts that an object may not be assigned a  value of a given Type.
        /// </summary>
        /// <typeparam name="T">The expected Type.</typeparam>
        /// <param name="actual">The object under examination</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotAssignableFrom<T>(object actual, string message)
        {
            Assert.That(actual, Is.Not.AssignableFrom(typeof(T)), message, null);
        }
        /// <summary>
        /// Asserts that an object may not be assigned a  value of a given Type.
        /// </summary>
        /// <typeparam name="T">The expected Type.</typeparam>
        /// <param name="actual">The object under examination</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotAssignableFrom<T>(object actual)
        {
            Assert.That(actual, Is.Not.AssignableFrom(typeof(T)), null, null);
        }
#endif

        #endregion

        #region IsInstanceOf

        /// <summary>
        /// Asserts that an object is an instance of a given type.
        /// </summary>
        /// <param name="expected">The expected Type</param>
        /// <param name="actual">The object being examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsInstanceOf(Type expected, object actual, string message, params object[] args)
        {
            Assert.That(actual, Is.InstanceOf(expected), message, args);
        }
        /// <summary>
        /// Asserts that an object is an instance of a given type.
        /// </summary>
        /// <param name="expected">The expected Type</param>
        /// <param name="actual">The object being examined</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsInstanceOf(Type expected, object actual, string message)
        {
            Assert.That(actual, Is.InstanceOf(expected), message, null);
        }
        /// <summary>
        /// Asserts that an object is an instance of a given type.
        /// </summary>
        /// <param name="expected">The expected Type</param>
        /// <param name="actual">The object being examined</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsInstanceOf(Type expected, object actual)
        {
            Assert.That(actual, Is.InstanceOf(expected), null, null);
        }

        /// <summary>
        /// Asserts that an object is an instance of a given type.
        /// </summary>
        /// <param name="expected">The expected Type</param>
        /// <param name="actual">The object being examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Obsolete]
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsInstanceOfType(Type expected, object actual, string message, params object[] args)
        {
            Assert.That(actual, Is.InstanceOf(expected), message, args);
        }
        /// <summary>
        /// Asserts that an object is an instance of a given type.
        /// </summary>
        /// <param name="expected">The expected Type</param>
        /// <param name="actual">The object being examined</param>
        /// <param name="message">The message to display in case of failure</param>
        [Obsolete]
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsInstanceOfType(Type expected, object actual, string message)
        {
            Assert.That(actual, Is.InstanceOf(expected), message, null);
        }
        /// <summary>
        /// Asserts that an object is an instance of a given type.
        /// </summary>
        /// <param name="expected">The expected Type</param>
        /// <param name="actual">The object being examined</param>
        [Obsolete]
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsInstanceOfType(Type expected, object actual)
        {
            Assert.That(actual, Is.InstanceOf(expected), null, null);
        }

        #endregion

        #region IsInstanceOf<T>

#if CLR_2_0 || CLR_4_0
        /// <summary>
        /// Asserts that an object is an instance of a given type.
        /// </summary>
        /// <typeparam name="T">The expected Type</typeparam>
        /// <param name="actual">The object being examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsInstanceOf<T>(object actual, string message, params object[] args)
        {
            Assert.That(actual, Is.InstanceOf(typeof(T)), message, args);
        }
        /// <summary>
        /// Asserts that an object is an instance of a given type.
        /// </summary>
        /// <typeparam name="T">The expected Type</typeparam>
        /// <param name="actual">The object being examined</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsInstanceOf<T>(object actual, string message)
        {
            Assert.That(actual, Is.InstanceOf(typeof(T)), message, null);
        }
        /// <summary>
        /// Asserts that an object is an instance of a given type.
        /// </summary>
        /// <typeparam name="T">The expected Type</typeparam>
        /// <param name="actual">The object being examined</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsInstanceOf<T>(object actual)
        {
            Assert.That(actual, Is.InstanceOf(typeof(T)), null, null);
        }
#endif

        #endregion

        #region IsNotInstanceOf

        /// <summary>
        /// Asserts that an object is not an instance of a given type.
        /// </summary>
        /// <param name="expected">The expected Type</param>
        /// <param name="actual">The object being examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotInstanceOf(Type expected, object actual, string message, params object[] args)
        {
            Assert.That(actual, Is.Not.InstanceOf(expected), message, args);
        }
        /// <summary>
        /// Asserts that an object is not an instance of a given type.
        /// </summary>
        /// <param name="expected">The expected Type</param>
        /// <param name="actual">The object being examined</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotInstanceOf(Type expected, object actual, string message)
        {
            Assert.That(actual, Is.Not.InstanceOf(expected), message, null);
        }
        /// <summary>
        /// Asserts that an object is not an instance of a given type.
        /// </summary>
        /// <param name="expected">The expected Type</param>
        /// <param name="actual">The object being examined</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotInstanceOf(Type expected, object actual)
        {
            Assert.That(actual, Is.Not.InstanceOf(expected), null, null);
        }

        /// <summary>
        /// Asserts that an object is not an instance of a given type.
        /// </summary>
        /// <param name="expected">The expected Type</param>
        /// <param name="actual">The object being examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Obsolete]
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotInstanceOfType(Type expected, object actual, string message, params object[] args)
        {
            Assert.That(actual, Is.Not.InstanceOf(expected), message, args);
        }
        /// <summary>
        /// Asserts that an object is not an instance of a given type.
        /// </summary>
        /// <param name="expected">The expected Type</param>
        /// <param name="actual">The object being examined</param>
        /// <param name="message">The message to display in case of failure</param>
        [Obsolete]
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotInstanceOfType(Type expected, object actual, string message)
        {
            Assert.That(actual, Is.Not.InstanceOf(expected), message, null);
        }
        /// <summary>
        /// Asserts that an object is not an instance of a given type.
        /// </summary>
        /// <param name="expected">The expected Type</param>
        /// <param name="actual">The object being examined</param>
        [Obsolete]
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotInstanceOfType(Type expected, object actual)
        {
            Assert.That(actual, Is.Not.InstanceOf(expected), null, null);
        }

        #endregion

        #region IsNotInstanceOf<T>

#if CLR_2_0 || CLR_4_0
        /// <summary>
        /// Asserts that an object is not an instance of a given type.
        /// </summary>
        /// <typeparam name="T">The expected Type</typeparam>
        /// <param name="actual">The object being examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotInstanceOf<T>(object actual, string message, params object[] args)
        {
            Assert.That(actual, Is.Not.InstanceOf(typeof(T)), message, args);
        }
        /// <summary>
        /// Asserts that an object is not an instance of a given type.
        /// </summary>
        /// <typeparam name="T">The expected Type</typeparam>
        /// <param name="actual">The object being examined</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotInstanceOf<T>(object actual, string message)
        {
            Assert.That(actual, Is.Not.InstanceOf(typeof(T)), message, null);
        }
        /// <summary>
        /// Asserts that an object is not an instance of a given type.
        /// </summary>
        /// <typeparam name="T">The expected Type</typeparam>
        /// <param name="actual">The object being examined</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotInstanceOf<T>(object actual)
        {
            Assert.That(actual, Is.Not.InstanceOf(typeof(T)), null, null);
        }
#endif

        #endregion

        #region Greater

        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(int arg1, int arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(int arg1, int arg2, string message)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(int arg1, int arg2)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(uint arg1, uint arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(uint arg1, uint arg2, string message)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(uint arg1, uint arg2)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(long arg1, long arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(long arg1, long arg2, string message)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(long arg1, long arg2)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(ulong arg1, ulong arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(ulong arg1, ulong arg2, string message)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(ulong arg1, ulong arg2)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(decimal arg1, decimal arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(decimal arg1, decimal arg2, string message)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(decimal arg1, decimal arg2)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(double arg1, double arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(double arg1, double arg2, string message)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(double arg1, double arg2)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(float arg1, float arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(float arg1, float arg2, string message)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(float arg1, float arg2)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(IComparable arg1, IComparable arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(IComparable arg1, IComparable arg2, string message)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is greater than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Greater(IComparable arg1, IComparable arg2)
        {
            Assert.That(arg1, Is.GreaterThan(arg2), null, null);
        }

        #endregion

        #region Less

        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(int arg1, int arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.LessThan(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(int arg1, int arg2, string message)
        {
            Assert.That(arg1, Is.LessThan(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(int arg1, int arg2)
        {
            Assert.That(arg1, Is.LessThan(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(uint arg1, uint arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.LessThan(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(uint arg1, uint arg2, string message)
        {
            Assert.That(arg1, Is.LessThan(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(uint arg1, uint arg2)
        {
            Assert.That(arg1, Is.LessThan(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(long arg1, long arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.LessThan(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(long arg1, long arg2, string message)
        {
            Assert.That(arg1, Is.LessThan(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(long arg1, long arg2)
        {
            Assert.That(arg1, Is.LessThan(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(ulong arg1, ulong arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.LessThan(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(ulong arg1, ulong arg2, string message)
        {
            Assert.That(arg1, Is.LessThan(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(ulong arg1, ulong arg2)
        {
            Assert.That(arg1, Is.LessThan(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(decimal arg1, decimal arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.LessThan(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(decimal arg1, decimal arg2, string message)
        {
            Assert.That(arg1, Is.LessThan(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(decimal arg1, decimal arg2)
        {
            Assert.That(arg1, Is.LessThan(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(double arg1, double arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.LessThan(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(double arg1, double arg2, string message)
        {
            Assert.That(arg1, Is.LessThan(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(double arg1, double arg2)
        {
            Assert.That(arg1, Is.LessThan(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(float arg1, float arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.LessThan(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(float arg1, float arg2, string message)
        {
            Assert.That(arg1, Is.LessThan(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(float arg1, float arg2)
        {
            Assert.That(arg1, Is.LessThan(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(IComparable arg1, IComparable arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.LessThan(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(IComparable arg1, IComparable arg2, string message)
        {
            Assert.That(arg1, Is.LessThan(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is less than the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Less(IComparable arg1, IComparable arg2)
        {
            Assert.That(arg1, Is.LessThan(arg2), null, null);
        }

        #endregion

        #region GreaterOrEqual

        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(int arg1, int arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(int arg1, int arg2, string message)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(int arg1, int arg2)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(uint arg1, uint arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(uint arg1, uint arg2, string message)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(uint arg1, uint arg2)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(long arg1, long arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(long arg1, long arg2, string message)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(long arg1, long arg2)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(ulong arg1, ulong arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(ulong arg1, ulong arg2, string message)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(ulong arg1, ulong arg2)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(decimal arg1, decimal arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(decimal arg1, decimal arg2, string message)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(decimal arg1, decimal arg2)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(double arg1, double arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(double arg1, double arg2, string message)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(double arg1, double arg2)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(float arg1, float arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(float arg1, float arg2, string message)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(float arg1, float arg2)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(IComparable arg1, IComparable arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(IComparable arg1, IComparable arg2, string message)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is greater than or equal tothe second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater</param>
        /// <param name="arg2">The second value, expected to be less</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void GreaterOrEqual(IComparable arg1, IComparable arg2)
        {
            Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2), null, null);
        }

        #endregion

        #region LessOrEqual

        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(int arg1, int arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(int arg1, int arg2, string message)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(int arg1, int arg2)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(uint arg1, uint arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(uint arg1, uint arg2, string message)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(uint arg1, uint arg2)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(long arg1, long arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(long arg1, long arg2, string message)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(long arg1, long arg2)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(ulong arg1, ulong arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(ulong arg1, ulong arg2, string message)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(ulong arg1, ulong arg2)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(decimal arg1, decimal arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(decimal arg1, decimal arg2, string message)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(decimal arg1, decimal arg2)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(double arg1, double arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(double arg1, double arg2, string message)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(double arg1, double arg2)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(float arg1, float arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(float arg1, float arg2, string message)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(float arg1, float arg2)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), null, null);
        }

        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(IComparable arg1, IComparable arg2, string message, params object[] args)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message, args);
        }
        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(IComparable arg1, IComparable arg2, string message)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message, null);
        }
        /// <summary>
        /// Verifies that the first value is less than or equal to the second
        /// value. If it is not, then an
        /// <see cref="AssertionException"/> is thrown. 
        /// </summary>
        /// <param name="arg1">The first value, expected to be less</param>
        /// <param name="arg2">The second value, expected to be greater</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void LessOrEqual(IComparable arg1, IComparable arg2)
        {
            Assert.That(arg1, Is.LessThanOrEqualTo(arg2), null, null);
        }

        #endregion

        #region Contains

        /// <summary>
        /// Asserts that an object is contained in a list.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The list to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Contains(object expected, ICollection actual, string message, params object[] args)
        {
            Assert.That(actual, new CollectionContainsConstraint(expected), message, args);
        }
        /// <summary>
        /// Asserts that an object is contained in a list.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The list to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Contains(object expected, ICollection actual, string message)
        {
            Assert.That(actual, new CollectionContainsConstraint(expected), message, null);
        }
        /// <summary>
        /// Asserts that an object is contained in a list.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The list to be examined</param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void Contains(object expected, ICollection actual)
        {
            Assert.That(actual, new CollectionContainsConstraint(expected), null, null);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Helper for Assert.AreEqual(double expected, double actual, ...)
        /// allowing code generation to work consistently.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="delta">The maximum acceptable difference between the
        /// the expected and the actual</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        protected static void AssertDoublesAreEqual(double expected, double actual, double delta, string message, object[] args)
        {
            if (double.IsNaN(expected) || double.IsInfinity(expected))
                Assert.That(actual, Is.EqualTo(expected), message, args);
            else
                Assert.That(actual, Is.EqualTo(expected).Within(delta), message, args);
        }

        private static int counter = 0;

        /// <summary>
        /// Gets the number of assertions executed so far and 
        /// resets the counter to zero.
        /// </summary>
        public static int Counter
        {
            get
            {
                int cnt = counter;
                counter = 0;
                return cnt;
            }
        }

        private static void IncrementAssertCount()
        {
            ++counter;
        }

        #endregion
    }
}
