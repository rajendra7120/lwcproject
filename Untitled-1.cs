12:02:53:066 USER_DEBUG [16]|DEBUG|TestSELECT Id, Latest_eGFR__c, Access_Placement_Status__c, KDE_Kidney_Replacement_Therapy_Options__c, Is_patient_on_track_for_optimal_start__c, Modality_Choice__c, AVF_Access_in_place__c, Planning_on_PD_or_AVG__c, Planning_on_Hospice_or_Palliative_Care__c, Is_patient_interested_in_transplant__c, Has_patient_been_referred__c, Name_of_Transplant_Center__c, Has_patient_been_accepted_and_listed__c, Other_notes__c, Send_message_to_physician__c, Has_a_living_donor_been_identified__c, Name_of_donor__c,
Latest_eGFR__c, Access_Placement_Status__c, KDE_Kidney_Replacement_Therapy_Options__c, Is_patient_on_track_for_optimal_start__c, Modality_Choice__c, AVF_Access_in_place__c, Planning_on_PD_or_AVG__c, Planning_on_Hospice_or_Palliative_Care__c, Is_patient_interested_in_transplant__c, Has_patient_been_referred__c, Name_of_Transplant_Center__c, Has_patient_been_accepted_and_listed__c, Other_notes__c, Send_message_to_physician__c, Has_a_living_donor_been_identified__c, Name_of_donor__c, Does_patient_need_a_donor_advocate__c, Circle_of_Care_Team_Member__c
public class CaseAssessmentGenericController {


    @AuraEnabled
    public static wrapperClass getFieldList(String StageName, String RecId) {
        wrapperClass wc = new wrapperClass();
       
        List<CaseAssessmentGenericMetaData__mdt> OptimalStartReadiness=[Select All_Fields__c, Columns__c,Tab_Title__c,Tab_Description__c
                                   From
                                   CaseAssessmentGenericMetaData__mdt Where 
                                   DeveloperName =: StageName.trim() ];
       
        
        String Query = 'SELECT Id, '+OptimalStartReadiness[0].All_Fields__c+ ' FROM PAP_TRI_Assessment__c WHERE Case__c = \''+RecId +'\' AND New_Case_stage__c = \'Optimal Start Readiness\' Limit 1';
                        
       System.debug('Test'+Query);
        
        List<PAP_TRI_Assessment__c> pApTri = (List<PAP_TRI_Assessment__c>) database.query(Query);
        wc.caseAssessmentId = pApTri[0].Id;
        wc.caseAssessment = pApTri[0];
        System.debug('Test2--'+wc.caseAssessmentId);
        List<fieldWrapper> fwLst = new List<fieldWrapper>();
        List<String> fieldLst = OptimalStartReadiness[0].All_Fields__c.split(',');
        Map<String, Schema.SObjectField> m = Schema.SObjectType.PAP_TRI_Assessment__c.fields.getMap(); 
        for(String st : fieldLst) {
            System.debug(st);
            st = st.trim();
            fieldWrapper fw = new fieldWrapper();        
	        fw.fieldName = st;
	        fw.fieldLabel = m.get(st).getDescribe().getLabel();
            fw.fieldValue = (String)pApTri[0].get(fw.fieldName);
            fwLst.add(fw);
         }
         system.debug(fwLst);
         wc.columnSize = Integer.valueOf(OptimalStartReadiness[0].Columns__c);
         wc.tabTitle = OptimalStartReadiness[0].Tab_Title__c;
         wc.tabDescription = OptimalStartReadiness[0].Tab_Description__c;
         wc.fwList = fwLst;
         system.debug('wc.tabTitle--'+wc.tabTitle);
         return wc;
        
    } 
    
    public class wrapperClass {
        @AuraEnabled
        public List<fieldWrapper> fwList;
        @AuraEnabled
        public Integer columnSize;
        @AuraEnabled
        public String tabDescription;
        @AuraEnabled
        public String tabTitle;
        @AuraEnabled
        public String caseAssessmentId;
        @AuraEnabled
        public PAP_TRI_Assessment__c caseAssessment;
        
        public wrapperClass() {
            fwList = new List<fieldWrapper>();
        }
    }

        public class fieldWrapper {
        @AuraEnabled
        public String fieldName;
        @AuraEnabled
        public String fieldLabel;
        @AuraEnabled
        public String readOnly;
        @AuraEnabled
        public String fieldValue;
    }

    /*Points - 
    1. Starting with the component - start 4-5 fields 
    2. start with all the fields on the component
    4. handling the layout part - like rows and columns 
    5. handling read only and edit on each fields
    6. handling edit and create 
    */
}