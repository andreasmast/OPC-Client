/* ========================================================================
 * Copyright (c) 2005-2013 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Opc.Ua.Client.Diagnostic.Controls
{
  public partial class ServerDiagnosticsDlg : Form
  {
    public ServerDiagnosticsDlg(Session session)
    {
      InitializeComponent();

      List<DiagnosticListViewItem> list = CreateItems(session);
      serverDiagnosticCtrl1.LoadItems(session, list);
    }
    public ServerDiagnosticsDlg(Session session, Subscription subscription)
    {
      InitializeComponent();
      List<DiagnosticListViewItem> list = CreateItems(session);
      serverDiagnosticCtrl1.LoadItems(session, list, subscription);
    }
    private void OnFormClosing(object sender, FormClosingEventArgs e)
    {
      serverDiagnosticCtrl1.Close();
    }
    private List<DiagnosticListViewItem> CreateItems(Session session)
    {
      List<DiagnosticListViewItem> items = new List<DiagnosticListViewItem>();
      NodeId serverNode = new NodeId(Objects.Server);
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.EnabledFlag", 0, false, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.ServerDiagnosticsSummary", 0, true, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.ServerDiagnosticsSummary.CumulatedSessionCount", 1, false, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.ServerDiagnosticsSummary.CumulatedSubscriptionCount", 1, false, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.ServerDiagnosticsSummary.CurrentSessionCount", 1, false, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.ServerDiagnosticsSummary.CurrentSubscriptionCount", 1, false, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.ServerDiagnosticsSummary.PublishingRateCount", 1, false, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.ServerDiagnosticsSummary.RejectedRequestsCount", 1, false, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.ServerDiagnosticsSummary.RejectedSessionCount", 1, false, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.ServerDiagnosticsSummary.SamplingRateCount", 1, false, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.ServerDiagnosticsSummary.SecurityRejectedRequestsCount", 1, false, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.ServerDiagnosticsSummary.SecurityRejectedSessionCount", 1, false, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.ServerDiagnosticsSummary.ServerViewCount", 1, false, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.ServerDiagnosticsSummary.SessionAbortCount", 1, false, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.ServerDiagnosticsSummary.SessionTimeoutCount", 1, false, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.SamplingRateDiagnosticsArray", 0, true, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.SubscriptionDiagnosticsArray", 0, true, true));
      items.Add(new DiagnosticListViewItem(serverNode,"ServerDiagnostics.SessionDiagnosticsSummary", 0, false, false));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.SessionDiagnosticsSummary.SessionDiagnosticsArray", 1, true, true));
      items.Add(new DiagnosticListViewItem(serverNode, "ServerDiagnostics.SessionDiagnosticsSummary.SessionSecurityDiagnosticsArray", 1, true, true));
                                                  
      return items;                               
    }                                             
                                                  
  }
}
