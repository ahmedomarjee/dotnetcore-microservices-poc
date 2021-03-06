﻿using PaymentService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Test.Domain
{
    public class PolicyAccountRepositoryTest : IPolicyAccountRepository
    {
        private readonly Dictionary<string, PolicyAccount> list = new Dictionary<string, PolicyAccount>();

        public PolicyAccountRepositoryTest()
        {
            list.Add("PA1", new PolicyAccount("POLICY_1", "231232132131"));
            list.Add("PA2", new PolicyAccount("POLICY_2", "389hfswjfrh2032r"));
            list.Add("PA3", new PolicyAccount("POLICY_3", "0rju130fhj20"));
        }

        public void Add(PolicyAccount policyAccount)
        {
            list.Add(policyAccount.PolicyNumber, policyAccount);
        }

        public ICollection<PolicyAccount> FindAll()
        {
            return list.Values;
        }

        public PolicyAccount FindByNumber(string accountNumber)
        {
            return list.Values.FirstOrDefault(x => x.PolicyAccountNumber == accountNumber);
        }

        public PolicyAccount FindForPolicy(string policyNumber)
        {
            return list.GetValueOrDefault(policyNumber);
        }
    }
}
