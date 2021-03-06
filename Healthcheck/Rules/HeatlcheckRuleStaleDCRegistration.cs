﻿//
// Copyright (c) Ping Castle. All rights reserved.
// https://www.pingcastle.com
//
// Licensed under the Non-Profit OSL. See LICENSE file in the project root for full license information.
//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PingCastle.Rules;

namespace PingCastle.Healthcheck.Rules
{
	[RuleModel("S-DCRegistration", RiskRuleCategory.StaleObjects, RiskModelCategory.Provisioning)]
	[RuleComputation(RuleComputationType.TriggerOnPresence, 10)]
    [RuleIntroducedIn(2,9)]
    [RuleDurANSSI(1, "dc_inconsistent_uac", "Domain controllers in inconsistent state")]
    public class HeatlcheckRuleStaleDCRegistrationEnabled : RuleBase<HealthcheckData>
    {
		protected override int? AnalyzeDataNew(HealthcheckData healthcheckData)
        {
            foreach (var dc in healthcheckData.DomainControllers)
            {
                if (!string.IsNullOrEmpty(dc.RegistrationProblem))
                {
                    AddRawDetail(dc.DCName, dc.RegistrationProblem);
                }
            }
            return null;
        }
    }
}
