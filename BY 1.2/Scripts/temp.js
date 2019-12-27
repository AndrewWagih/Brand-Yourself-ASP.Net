new Vue({
    'el': '#temp',
    data() {
        return {
            personalInfoData: null,
            summaryData: null,
            expData: null,        
            eduData: null,
            skillData: null,
            langData: null,
            courseData: null,
            certData: null,
            
        }
    },
    mounted() {
        this.FetchAllPersonalInfo();
        this.FetchAllSummary();
        this.FetchAllExp();
        this.FetchAllEdu();
        this.FetchAllSkills();
        this.FetchAllLang();
        this.FetchAllCourse();
        this.FetchAllCert();
    },
    methods: {        
        // Personal Info
        FetchAllPersonalInfo() {
            var t = this;
            $.ajax
                ({
                    
                    type: 'GET',
                    url: '/PersonalInfo/FetchAllPersonalInfo',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    //data: { 'n': t.idd },
                    success: function (data) {
                        console.log("Personal");
                        console.log(data);
                        t.personalInfoData = data;
                    }
                })
        },
        // End PErsonal Info
        // Summary
        FetchAllSummary() {
            var t = this;
            $.ajax
                ({
                    type: 'get',
                    url: '/Summary/FetchAllSummary',
                    dataType: 'json',
                    //data: JSON.stringify(t.fetchP),
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        console.log("summary");
                        console.log(data);
                        t.summaryData = data;
                    }
                })
        },
        //End Summary
        // Experience
        FetchAllExp() {
            var t = this;
            $.ajax
                ({
                    type: 'get',
                    url: '/Experience/FetchAllExperience',
                    dataType: 'json',
                    //data: JSON.stringify(t.expData),
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        console.log("Experience");
                        console.log(data);
                        t.expData = data;
                    }
                })
        },
        // End Experience
        // Education 
        FetchAllEdu() {
            var t = this;
            $.ajax
                ({
                    type: 'get',
                    url: '/Education/FetchAllEducation',
                    dataType: 'json',
                    //data: JSON.stringify(t.expData),
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        console.log("Education");
                        console.log(data);
                        t.eduData = data;
                    }
                })
        },
        // End Education 
        // Skill
        FetchAllSkills() {
            var t = this;
            $.ajax
                ({
                    type: 'get',
                    url: '/Skills/FetchAllSkills',
                    dataType: 'json',
                    //data: { 'skill': t.addSkill.skill, 'n': t.addSkill.user_id},
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        console.log("Skills");
                        console.log(data);
                        t.skillData = data;
                    }
                })
        },        
        // End Skill
        // Language
        FetchAllLang() {
            var t = this;
            $.ajax
                ({
                    type: 'get',
                    url: '/Language/FetchAllLanguage',
                    dataType: 'json',
                    //data: JSON.stringify(t.langData),
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        console.log("lang");
                        console.log(data);
                        t.langData = data;
                    }
                })
        },
        // End Language
        //Course
        FetchAllCourse() {
            var t = this;
            $.ajax
                ({
                    type: 'get',
                    url: '/Courses/FetchAllCourses',
                    dataType: 'json',
                    //data: JSON.stringify(t.courseData),
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        console.log("Course");
                        console.log(data);
                        t.courseData = data;
                    }
                })
        },        
        // end course
        // Certificates
        FetchAllCert() {
            var t = this;
            $.ajax
                ({
                    type: 'get',
                    url: '/Certificates/FetchAllCertificates',
                    dataType: 'json',
                    //data: JSON.stringify(t.certData),
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        console.log("Certificates");
                        console.log(data);
                        t.certData = data;
                    }
                })
        },
        // End Certificates
    }
});
