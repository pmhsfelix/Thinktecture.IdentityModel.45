﻿/*
 * Copyright (c) Dominick Baier, Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Thinktecture.IdentityModel
{
    internal static class Tracing
    {
        private static TraceSource _ts = new TraceSource("Thinktecture.IdentityModel");

        [DebuggerStepThrough]
        public static void Start(string message)
        {
            TraceEvent(TraceEventType.Start, message);
        }

        [DebuggerStepThrough]
        public static void Stop(string message)
        {
            TraceEvent(TraceEventType.Stop, message);
        }

        [DebuggerStepThrough]
        public static void Information(string message)
        {
            TraceEvent(TraceEventType.Information, message);
        }

        [DebuggerStepThrough]
        public static void InformationFormat(string message, params object[] objects)
        {
            TraceEventFormat(TraceEventType.Information, message, objects);
        }

        [DebuggerStepThrough]
        public static void Warning(string message)
        {
            TraceEvent(TraceEventType.Warning, message);
        }

        [DebuggerStepThrough]
        public static void WarningFormat(string message, params object[] objects)
        {
            TraceEventFormat(TraceEventType.Warning, message, objects);
        }

        [DebuggerStepThrough]
        public static void Error(string message)
        {
            TraceEvent(TraceEventType.Error, message);
        }

        [DebuggerStepThrough]
        public static void ErrorVerbose(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            TraceEventFormat(TraceEventType.Error, "{0}\n\nMethod: {1}\nFilename: {2}\nLine number: {3}", message, memberName, filePath, lineNumber);
        }

        [DebuggerStepThrough]
        public static void ErrorFormat(string message, params object[] objects)
        {
            TraceEventFormat(TraceEventType.Error, message, objects);
        }

        [DebuggerStepThrough]
        public static void Verbose(string message)
        {
            TraceEvent(TraceEventType.Verbose, message);
        }

        [DebuggerStepThrough]
        public static void VerboseFormat(string message, params object[] objects)
        {
            TraceEventFormat(TraceEventType.Verbose, message, objects);
        }

        [DebuggerStepThrough]
        public static void Transfer(string message, Guid activity)
        {
            _ts.TraceTransfer(0, message, activity);
        }

        [DebuggerStepThrough]
        public static void TraceEventFormat(TraceEventType type, string message, params object[] objects)
        {
            var format = string.Format(message, objects);
            TraceEvent(type, format);
        }

        [DebuggerStepThrough]
        public static void TraceEvent(TraceEventType type, string message)
        {
            if (Trace.CorrelationManager.ActivityId == Guid.Empty)
            {
                Trace.CorrelationManager.ActivityId = Guid.NewGuid();
            }

            _ts.TraceEvent(type, 0, message);
        }
    }
}



///*
// * Copyright (c) Dominick Baier.  All rights reserved.
// * see license.txt
// */

//using System;
//using System.Diagnostics;
//using Thinktecture.IdentityModel.Constants;

//namespace Thinktecture.IdentityModel.Diagnostics
//{
//    /// <summary>
//    /// Helper class for Tracing
//    /// </summary>
//    internal static class Tracing
//    {
//        [DebuggerStepThrough]
//        public static void Start(string area)
//        {
//            TraceEvent(TraceEventType.Start, area, "Start");
//        }

//        [DebuggerStepThrough]
//        public static void Stop(string area)
//        {
//            TraceEvent(TraceEventType.Stop, area, "Stop");
//        }

//        [DebuggerStepThrough]
//        public static void Information(string area, string message)
//        {
//            TraceEvent(TraceEventType.Information, area, message);
//        }

//        [DebuggerStepThrough]
//        public static void Warning(string area, string message)
//        {
//            TraceEvent(TraceEventType.Warning, area, message);
//        }

//        [DebuggerStepThrough]
//        public static void Error(string area, string message)
//        {
//            TraceEvent(TraceEventType.Error, area, message);
//        }

//        [DebuggerStepThrough]
//        public static void Verbose(string area, string message)
//        {
//            TraceEvent(TraceEventType.Verbose, area, message);
//        }

//        [DebuggerStepThrough]
//        public static void TraceEvent(TraceEventType type, string area, string message)
//        {
//            TraceSource ts = new TraceSource(Internal.TraceSourceName);

//            if (Trace.CorrelationManager.ActivityId == Guid.Empty)
//            {
//                if (type != TraceEventType.Verbose)
//                {
//                    Trace.CorrelationManager.ActivityId = Guid.NewGuid();
//                }
//            }

//            ts.TraceEvent(type, 0, string.Format("{0}: {1}", area, message));
//        }
//    }
//}