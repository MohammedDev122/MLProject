using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBl
{
    public static class FailCauses
    {
        public static Dictionary<int, string> Cause = new Dictionary<int, string> { {0,"Unkown Error" },
            { 1, "اسم التحليل قصير للغاية" }, { 2, "السعر خالي" }
        , { 3, "السعر لا يمكن ان يكون بقيمة سالبة" }, { 4, "خطأ من البيانات الخاصة بالتحاليل" },
            { 5, "اسم الباكدج قصير للغاية" },{ 6, "لا يمكن ان يكون اسم التحليل مجرد فراغات" },{ 7, "لا يمكن ان يكون اسم الباقة مجرد فراغات" }
        , { 8, "خطأ من بيانات الباقة" },{ 9, "المعرف لا يمكن ان يكون قيمة سالبة" },{ 10, "لا يمكن العثور علي الباقة صاحبة هذا المعرف" },
        { 11, "Can't Find Analysis With the inserted ID" },{ 12, "Error From Contains DB" },{ 13, "Error From Prescriptions DB" },
        { 14, "Password Is Less Than 8 Characters" },{ 15, "Password At Least Should Hold 1 Character" },
        { 16, "User Name Is less than 5 characters" },{ 17, "User Name Is More than 10 characters" },
            { 18, "User Name Can't Hold Numbers" },{ 19, "User Name Is Similar To Existing One" },{ 20, "User Name Can't Hold White Spaces" },
        { 21, "User With The Same Name Already Exist" },{ 22, "Error From Users DB" },
            { 23, "Number Of Items In The Prescription Can't Be Bellow Zero" },{ 24, "User Do Not Exist" },{ 25, "Wrong Prescription ID" },
       { 26, "Wrong Analysis ID" },  { 27, "Error From Items DB" },{ 28, "Error With Saving Prescription" },{ 29, "Disscount Percantage Can not Exceed 1" },
      { 30, "Disscount Percantage Can not be Negative" },
            { 31, "error from disscount DB" }, { 32, "Password Can't Hold Any White Spaces" },{ 33, "User Name Is Empty" }, { 34, "Password Is Empty" }
            ,{35,"اسم التحليل لا يمكن ان يكون مجرد ارقام" },{36,"اسم التحليل لا يمكن ان يحتوي فقط  علي مسافات بيضاء" },{37,"اسم التحليل لا يمكن ان يكون فارغ" }
            ,{38,"حقل التسعير لا يجب ان يحتوي علي حروف" }    ,{39,"حقل التسعير لا يجب ان يحتوي علي مسافات بيضاء" } ,{40,"اسم الباقة لا يمكن ان تكون مجرد ارقام" }
            ,{41,"اسم الباقة لا يمكن ان يحتوي فقط  علي مسافات بيضاء" },{42,"اسم الباقة لا يمكن ان يكون فارغ" }
            ,{43,"التحليل متواجد بالفعل في الباقة" }  ,{44,"التحليل متواجد بالفعل في الروشتة" },
            {45,"رقم الهاتف لا يمكن ان يكون فارغ" }
            ,{46,"رقم الهاتف غير صحيح" },{47,"الاسم لا يحتوي علي ارقام" }
            ,{48,"الاسم فارغ" },{49,"التاريخ في المستقبل" }  ,{50,"التاريخ في الماضي" },{51,"لا توجد مدينة بهذا ال ID" },{52,"لا توجد منطقة بهذا ال ID" }
        ,{53,"المنطقة المسجلة لا تقع في تلك المدينة" },{54,"خطأ من البيانات الخاصة بالعميل" },{55,"المعرف الخاص بالباقة خاطئ" }
            ,{56,"الباقة ليست معروضة" } ,{57,"خطأ في معرف الخصومات" },{58,"لا يوجد عميل بهذا المعرف"},{59,"خطأ من بيانات الحجز"},{60,"حجز او انتهي"}
            ,{61,"خطأ من البيانات الخاصة بالزيارات"}

        };
        public enum enFailCauses
        {
            enUnkownError = 0, enAnalysisNameIsTooShort = 1, enCostIsNull = 2, enCostIsNegative = 3,
            enErrorFromAnalysisDB = 4, enPackageNameIsTooShort = 5, enAnalysisNameIsOnlySpaces = 6,
            enPackageNameIsOnlySpaces = 7, enErrorFromPackagesDB = 8, enIDCantBeNegative = 9
                , enCantFindPackageWithTheInsertedID = 10, enCantFindAnalysisWithTheInsertedID = 11
                , enErrorFromContainsDB = 12, enErrorFromPrescriptionsDB = 13, enPasswordIsLessThan8Characters = 14
                , enPasswrodDosentHoldAnyChars = 15, enUserNameIsLessThan5Chars = 16, enUserNameIsMoreThan10Chars = 17,
            enUserNameCantHoldNums = 18, enUserNameIsSimillarToExistingOne = 19,
            enUserNameCantHoldWhiteSpaces = 20, enUserWithTheSameNameAlreadyExist = 21, enErrorFromUsersDB = 22, enNumOfItemsCantBeBellowZero = 23,
            enUserDoNotExist = 24, enWrongPrescriptionID = 25, enWrongAnalysisID = 26, enErrorFromItemsDB = 27, enErrorWithSavingPrescription = 28,
            enDisscountPercantageCanNotExceed1 = 29, enDisscountPercantageCanNotBeNegative = 30, enErrorFromDisscountDB = 31,
            enPasswordCantHoldAnyWhiteSpaces = 32, enUserNameIsEmpty = 33, enPasswordIsEmpty = 34, enAnalysisNameCannotBeOnlyNums = 35
               , enAnalysisNameCantOnlyContainWhiteSpaces = 36, enAnalysisNameCantBeEmpty = 37, enCostFieldCantHoldChars = 38
                , enCostFieldCanNotHoldWhiteSpaces = 39, enPackageNameCannotBeOnlyNums = 40, enPackageNameCantOnlyContainWhiteSpaces = 41,
            enPackageNameCantBeEmpty = 42, enAnalysisAlreadyExistsInThisPackage = 43,
            enAnalysisAlreadyExistsInThisPrescription = 44, enPhoneCantBeEmpty = 45, enWrongPhoneNum = 46, enNameCantHoldNums = 47, enNameIsEmpty = 48, enDateInFuture = 49, enDateInPaste = 50
                , enWrongCityID = 51, enWrongRegionID = 52, enRegionDoNotExistInTheCity = 53, enErrorFromClientDB = 54
                , enWrongPackageID = 55, enPackageIsntONTheMarket = 56, enWrongDisscountID = 57, enNoClientID = 58, enErrorFromBookingDB = 59
, enFinishedOrCancelled = 60, enErrorFromVisitDB = 61
        }
    }
}
