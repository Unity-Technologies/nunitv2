#region Copyright (c) 2002, James W. Newkirk, Michael C. Two, Alexei A. Vorontsov, Philip A. Craig
/************************************************************************************
'
' Copyright � 2002 James W. Newkirk, Michael C. Two, Alexei A. Vorontsov
' Copyright � 2000-2002 Philip A. Craig
'
' This software is provided 'as-is', without any express or implied warranty. In no 
' event will the authors be held liable for any damages arising from the use of this 
' software.
' 
' Permission is granted to anyone to use this software for any purpose, including 
' commercial applications, and to alter it and redistribute it freely, subject to the 
' following restrictions:
'
' 1. The origin of this software must not be misrepresented; you must not claim that 
' you wrote the original software. If you use this software in a product, an 
' acknowledgment (see the following) in the product documentation is required.
'
' Portions Copyright � 2002 James W. Newkirk, Michael C. Two, Alexei A. Vorontsov 
' or Copyright � 2000-2002 Philip A. Craig
'
' 2. Altered source versions must be plainly marked as such, and must not be 
' misrepresented as being the original software.
'
' 3. This notice may not be removed or altered from any source distribution.
'
'***********************************************************************************/
#endregion

using System;
using NUnit.Core;
using NUnit.Util;

namespace NUnit.UiKit
{
	/// <summary>
	/// Handlers for events related to loading and unloading test suites
	/// </summary>
	public delegate void TestSuiteLoadedHandler( UITestNode test, string assemblyFileName);
	public delegate void TestSuiteChangedHandler( UITestNode test );
	public delegate void TestSuiteUnloadedHandler();
	public delegate void TestSuiteLoadFailureHandler( string assemblyFileName, Exception exception );

	/// <summary>
	/// Handler for event generated by a test browser
	/// </summary>
	public delegate void SelectedTestChangedHandler( UITestNode test );

	/// <summary>
	///  Handlers for events related to running tests
	/// </summary>
	public delegate void RunStartingHandler( UITestNode test );
	public delegate void RunFinishedHandler( TestResult result );
	public delegate void RunCanceledHandler( UITestNode test );
	public delegate void RunFailureHandler( Exception exception );

	public delegate void SuiteStartedHandler( UITestNode suite );
	public delegate void SuiteFinishedHandler( TestSuiteResult result );

	public delegate void TestStartedHandler( UITestNode testCase );
	public delegate void TestFinishedHandler( TestCaseResult result );

	/// <summary>
	/// UIEvents interface consists of a set of events that are fired
	/// as test suites are loaded and unloaded and as tests are run.
	/// 
	/// In order to isolate client code from the loading and unloading 
	/// of test domains, events that formerly took a Test, TestCase or 
	/// TestSuite as an argument, now use a TestInfo object which gives
	/// the same information but isn't connected to the remote domain.
	/// 
	/// The TestInfo object may in some cases be created using lazy 
	/// evaluation of child TestInfo objects. Since evaluation of these
	/// objects does cause a cross-domain reference, the client code
	/// should access the full tree immediately, rather than at a later
	/// time, if that is what is needed. This will normally happen if
	/// the client building a tree, for example. However, some clients
	/// may only want the name of the test being run and passing the
	/// fully evaluated tree would be unnecessary for them.
	/// 
	/// See comments associated with each event for lifetime limitations 
	/// on the objects passed to the delegates.
	/// </summary>
	public interface UIEvents
	{
		/// <summary>
		/// Test suite was loaded. The TestInfo uses lazy evaluation
		/// of child tests, so a client that needs information from
		/// all levels should traverse the tree immediately to ensure
		/// that they are expanded. Clients that only need a field
		/// from the top level test don't need to do that. Since
		/// that's what the clients would normally do anyway, this
		/// should not cause a problem except in pathological cases.
		/// </summary>
		event TestSuiteLoadedHandler TestSuiteLoadedEvent;
		
		/// <summary>
		/// Current test suite has changed. The new information should
		/// replace or be merged with the old, depending on the needs
		/// of the client. Lazy evaluation applies here too.
		/// </summary>
		event TestSuiteChangedHandler TestSuiteChangedEvent;
		
		/// <summary>
		/// Test suite unloaded. The old information is still
		/// available to the client - for example to produce any
		/// reports - but will normally be removed from the UI.
		/// </summary>
		event TestSuiteUnloadedHandler TestSuiteUnloadedEvent;
		
		/// <summary>
		/// A failure occured in loading an assembly. This may be as
		/// a result of a client request to load an assembly or as a 
		/// result of an asynchronous change that required reloading 
		/// the assembly. In the first case, the loaded assembly has
		/// not been replaced unless the assemblyFileName is the same.
		/// In the second case, the client will usually treat this
		/// as a sort of involuntary unload.
		/// </summary>
		event TestSuiteLoadFailureHandler TestSuiteLoadFailureEvent;

		/// <summary>
		/// The following events signal that a test run, test suite
		/// or test case has started. If client is holding the entire 
		/// tree of tests that was previously loaded, this TestInfo 
		/// should match one of them, but it won't generally be the 
		/// same object. Best practice is to match the TestInfo with 
		/// one that is already held rather than expanding it to 
		/// create lots of new objects. In the future, these events
		/// may just pass the name of the test.
		/// </summary>
		event RunStartingHandler RunStartingEvent;
		
		event SuiteStartedHandler SuiteStartedEvent;
		
		event TestStartedHandler TestStartedEvent;
		
		/// <summary>
		/// The following events signal that a test run, test suite or
		/// test case has finished. Client should make use of the result
		/// value during the life of the call only. If the result is to
		/// be saved in the application, it should be converted to a
		/// TestResultInfo, which will cause it's internal Test reference
		/// to be converted to a local TestInfo object.
		/// 
		/// NOTE: These cannot be converted to use TestResultInfo directly
		/// because some client code makes use of ResultVisitor which would
		/// also have to be changed. Maybe later...
		/// </summary>
		event RunFinishedHandler RunFinishedEvent;

		event RunCanceledHandler RunCanceledEvent;

		event RunFailureHandler RunFailureEvent;
		
		event SuiteFinishedHandler SuiteFinishedEvent;
		
		event TestFinishedHandler TestFinishedEvent;
	}
}
