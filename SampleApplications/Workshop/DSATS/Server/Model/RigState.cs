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
using System.Linq;
using System.Text;
using Opc.Ua;

namespace DsatsDemo
{
    public partial class RigState
    {
        #region Public Methods
        /// <summary>
        /// Sets the phase for the rig.
        /// </summary>
        public void SetPhase(NodeId phaseId)
        {
            if (m_knownPhases == null)
            {
                m_knownPhases = new List<NodeId>();
            }

            m_knownPhases.Add(phaseId);
        }

        /// <summary>
        /// Returns true if the phase is valid.
        /// </summary>
        public bool IsValidPhase(NodeId phaseId)
        {
            if (m_knownPhases != null)
            {
                return m_knownPhases.Contains(phaseId);
            }

            return false;
        }
        #endregion

        #region Private Fields
        private List<NodeId> m_knownPhases;
        #endregion
    }
}
