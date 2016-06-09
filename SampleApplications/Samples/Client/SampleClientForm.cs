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
using System.Reflection;

using Opc.Ua.Client;
using Opc.Ua.Client.Controls;
using Opc.Ua.Sample.Controls;
using Opc.Ua.Configuration;

namespace Opc.Ua.Sample
{
    public partial class SampleClientForm : Opc.Ua.Sample.Controls.ClientForm
    {
        public SampleClientForm()
        {
            InitializeComponent();
        }

        public SampleClientForm(
            ApplicationInstance application, 
            Opc.Ua.Sample.Controls.ClientForm masterForm, 
            ApplicationConfiguration configuration)
        :
            base(configuration.CreateMessageContext(), application, masterForm, configuration)
        {
            InitializeComponent();
            
            base.BrowseCTRL.MethodCalled += new Opc.Ua.Sample.Controls.MethodCalledEventHandler(BrowseCTRL_MethodCalled);

            if (!configuration.SecurityConfiguration.AutoAcceptUntrustedCertificates)
            {
                configuration.CertificateValidator.CertificateValidation += new CertificateValidationEventHandler(CertificateValidator_CertificateValidation);
            }
        }

        void CertificateValidator_CertificateValidation(CertificateValidator validator, CertificateValidationEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new CertificateValidationEventHandler(CertificateValidator_CertificateValidation), validator, e);
                return;
            }

            try
            {
                GuiUtils.HandleCertificateValidationError(this, validator, e);
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        void BrowseCTRL_MethodCalled(object sender, Opc.Ua.Sample.Controls.MethodCalledEventArgs e)
        {            
            try
            {
                // TBD
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
