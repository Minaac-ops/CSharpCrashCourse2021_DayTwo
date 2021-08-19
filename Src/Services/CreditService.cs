using System;
using CrashCourse2021ExercisesDayTwo.Models;

namespace CrashCourse2021ExercisesDayTwo.Services
{
    //This is the only Class where you should change code!! :)
    public class CreditService
    {
        private Credit credit;

        public CreditService()
        {
            credit = new Credit { Value = 0, MaxAllowed = 10000d};
        }

        internal double CurrentCreditValue()
        {
            return credit.Value;
        }

        internal void AddCredit(double valueToAdd)
        {
            double tooMuchAdded = credit.MaxAllowed-credit.Value;
            if (valueToAdd < 0)
            {
                throw new ArgumentException(Constants.CreditToAddMustBeZeroOrMoreException);
            } else if (valueToAdd>tooMuchAdded)
            {
                throw new ArgumentException(Constants.CreditCannotExceedMaxValueException);
            }
            else
            {
                this.credit.Value = valueToAdd + CurrentCreditValue();
            }
        }

        internal void RemoveCredit(double valueToRemove)
        {
            if (valueToRemove<0)
            {
                throw new ArgumentException(Constants.CreditToRemoveMustBeZeroOrMoreException);
            } else if ((credit.Value-valueToRemove)<0)
            {
                throw new ArgumentException(Constants.CreditCannotBeLessThenZeroException);
            }
            this.credit.Value = CurrentCreditValue() - valueToRemove;
        }

        internal double CurrentMaxAllowedValue()
        {
            return credit.MaxAllowed;
        }

        internal void SetMaxAllowedValue(double maxValue)
        {
            if (maxValue>1000000000)
            {
                throw new ArgumentException(Constants.CreditMaxValueCannotBeAboveABillionException);
            } else if (maxValue < 0)
            {
                throw new ArgumentException(Constants.CreditMaxValueMustBeAboveZeroException);
            }
            this.credit.MaxAllowed = maxValue;
        }
    }
}
