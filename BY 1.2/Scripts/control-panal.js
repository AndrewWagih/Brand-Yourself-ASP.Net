new Vue({
    'el': '#app',
    data() {
        return {
            j: window.location.pathname,
            firstName: 'andrew',
            lastName: 'wagih',
            userName: 'Beblawy',
            dropdownUrerInfo: false,
            isActive: false,
            PersonalInfo: false,
            Summary: false,
            Experience: false,
            Education: false,
            Skills: false,
            Language: false,
            Interests: false,
            Certificates: false,
            Conferences: false,
            Courses: false,
            Publications: false,
            References: false,
            Software: false,
            userInfo: [],
            // Personal Info
            personalInfoData: null,
            newP: {
                first_name: '',
                last_name: '',
                email: '',
                phone_number: '',
                birthday: '',
                profession: '',
                address: '',
                user_id: '1',
            },
            UpdateP: {
                id: 1,
                first_name: '',
                last_name: '',
                email: '',
                phone_number: '',
                birthday: '',
                profession: '',
                address: '',
                user_id: '1',
            },
            fetchP: {
                user_id: '1'
            },
            // End Personal Info

            // Summary
            summaryData: null,
            addSummary: {
                description: '',
                user_id: '1'
            },
            //End Sumary
            // Experience
            expData: null,
            addExp: {
                position: '',
                company: '',
                date_from: '',
                date_to: '',
                description: '',
                user_id: '1'
            },
            // End Experience
            //Education
            eduData: null,
            addEdu: {
                school_name: '',
                description: '',
                date_from: '',
                date_to: '',
                user_id: '1'
            },
            // End Education
            //Skills
            skillData: null,
            addSkill: {
                skill_nam: '',
                user_id: '1'
            },
            // End skill
            //Language
            langData: null,
            addLang: {
                language_name: '',
                mastery: '',
                user_id: '1'
            },
            // End Language
            // Course
            courseData: null,
            addCourse: {
                name: '',
                date_to: '',
                date_from: '',
                user_id: '1'
            },
            // End Course

            //Certificates
            certData: null,
            addCert: {
                title: '',
                date_to: '',
                date_from: '',
                user_id: '1'
            },
            //End Certificates
            idd: '1',
            loginData: { 'em': '', 'pass': '' }
        }
    },
    mounted() {
        this.j = this.j.replace('/Control/', '');
        this.setActive(this.j);
        if (this.j == 'PersonalInfo') { this.FetchAllPersonalInfo(); }
        if (this.j == 'Summary') { this.FetchAllSummary(); }
        if (this.j == 'Experience') { this.FetchAllExp();}
        if (this.j == 'Education') { this.FetchAllEdu();}
        if (this.j == 'Skills') { this.FetchAllSkills();}
        if (this.j == 'Language') { this.FetchAllLang();}
        if (this.j == 'Courses') { this.FetchAllCourse();}
        if (this.j == 'Certificates') { this.FetchAllCert();}
    },
    methods: {
        allUsers() {
            var t = this;
            $.ajax
                ({
                    type: 'get',
                    url: '/Login/Login',
                   // dataType: 'json',
                   // contentType: "application/json;charset=utf-8",
                    data: { 'em': 'andrewwagih@gmail.com', 'pass':'123456'},
                    success: function (data) {
                        console.log('user');
                        console.log(data);
                        t.userInfo = data;

                    }
                })
        },
        login() {
            var t = this;
            $.ajax
                ({
                    type: 'post',
                    url: '/Login/Login',
                     //dataType: 'json',
                     //contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(t.loginData),
                    success: function (data) {
                        console.log('user');
                        console.log(data);
                        t.userInfo = data;

                    }
                })
        },
        toggle() {
            if (this.dropdownUrerInfo == false) {
                this.dropdownUrerInfo = true
            } else {
                this.dropdownUrerInfo = false
            }

        },
        setActive($class) {

            this.PersonalInfo = false,
                this.Summary = false,
                this.Experience = false,
                this.Education = false,
                this.Skills = false,
                this.Language = false,
                this.Interests = false,
                this.Certificates = false,
                this.Conferences = false,
                this.Courses = false,
                this.Publications = false,
                this.References = false,
                this.Software = false,
                this.Licenses = false,
                this.Text = false,
                this.Additional = false,
                Vue.set(this.$data, $class, true)
        },
        showCV() {
            window.location.href = 'http://localhost:8000/cv/' + this.userName
        },
        // Personal Info
        AddNewPersonalInfo() {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/PersonalInfo/addNewPersonalInfo',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(t.newP),
                    success: function (data) {
                        console.log(data);
                        t.personalInfoData.push(data);
                    }
                });
        },
        updatePersonal(dataa) {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/PersonalInfo/UpdatePersonalInfo',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(dataa),
                    success: function (data) {
                        console.log(data);
                    }
                })
        },
        deletePersonal(dataa) {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/PersonalInfo/DeletePersonalInfo',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(dataa),
                    success: function (data) {
                        console.log(data);
                        t.personalInfoData.splice(t.personalInfoData.indexOf(dataa), 1);
                    }
                })
        },
        FetchAllPersonalInfo() {
            var t = this;
            $.ajax
                ({
                    //type: 'get',
                    //url: '/PersonalInfo/FetchAllPersonalInfo',
                    //dataType: 'json',
                    //data: JSON.stringify(t.fetchP),
                    //contentType: "application/json;charset=utf-8",
                    type: 'GET',
                    url: '/PersonalInfo/FetchAllPersonalInfo',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    //data: JSON.stringify(t.newP),
                    data: { 'n': t.idd },
                    success: function (data) {
                        console.log("Personal");
                        console.log(data);
                        t.personalInfoData = data;
                        //t.userInfo = data;

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
                    data: JSON.stringify(t.fetchP),
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        console.log("summary");
                        console.log(data);
                        t.summaryData = data;
                        //t.userInfo = data;

                    }
                })
        },

        AddNewSummary() {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Summary/addNewSummery',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(t.addSummary),
                    success: function (data) {
                        console.log(data);
                        t.summaryData.push(data);
                    }
                });
        },

        updateSummary(dataa) {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Summary/UpdateSummary',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(dataa),
                    success: function (data) {
                        console.log(data);
                    }
                })
        },

        deleteSummary(dataa) {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Summary/DeleteSummary',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(dataa),
                    success: function (data) {
                        console.log(data);
                        t.summaryData.splice(t.summaryData.indexOf(dataa), 1);
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
                    data: JSON.stringify(t.expData),
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        console.log("Experience");
                        console.log(data);
                        t.expData = data;
                        //t.userInfo = data;

                    }
                })
        },

        AddNewExp() {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Experience/addNewExperience',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(t.addExp),
                    success: function (data) {
                        console.log(data);
                        t.expData.push(data);
                    }
                });
        },

        updateExp(dataa) {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Experience/UpdateExperience',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(dataa),
                    success: function (data) {
                        console.log(data);
                        
                    }
                })
        },

        deleteExp(dataa) {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Experience/DeleteExperience',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(dataa),
                    success: function (data) {
                        console.log(data);
                        t.expData.splice(t.expData.indexOf(dataa), 1);
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
                    data: JSON.stringify(t.expData),
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        console.log("Education");
                        console.log(data);
                        t.eduData = data;
                        //t.userInfo = data;

                    }
                })
        },

        AddNewEdu() {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Education/addNewEducation',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(t.addEdu),
                    success: function (data) {
                        console.log(data);
                        t.eduData.push(data);
                    }
                });
        },

        updateEdu(dataa) {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Education/UpdateEducation',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(dataa),
                    success: function (data) {
                        console.log(data);

                    }
                })
        },

        deleteEdu(dataa) {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Education/DeleteEducation',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(dataa),
                    success: function (data) {
                        console.log(data);
                        t.eduData.splice(t.eduData.indexOf(dataa), 1);
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
                    //data: JSON.stringify(t.skillData),
                    data: { 'skill': t.addSkill.skill, 'n': t.addSkill.user_id},
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        console.log("Skills");
                        console.log(data);
                        t.skillData = data;
                        //t.userInfo = data;

                    }
                })
        },

        AddNewSkill() {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Skills/addNewSkills',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(t.addSkill),
                    success: function (data) {
                        console.log(data);
                        t.skillData.push(data);
                    }
                });
        },

        updateSkill(dataa) {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Skills/UpdateSkills',
                    dataType: 'json',
                    contentType: 'application/json;charset=utf-8',
                    //data: { 'id': dataa.id, 'skill': dataa.skill},
                    data: JSON.stringify(dataa),
                    success: function (data) {
                        console.log(data);

                    }
                })
        },

        deleteSkill(dataa) {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Skills/DeleteSkills',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(dataa),
                    success: function (data) {
                        console.log(data);
                        t.skillData.splice(t.skillData.indexOf(dataa), 1);
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
                    data: JSON.stringify(t.langData),
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        console.log("lang");
                        console.log(data);
                        t.langData = data;
                        //t.userInfo = data;

                    }
                })
        },
        AddNewLang() {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Language/addNewLanguage',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(t.addLang),
                    success: function (data) {
                        console.log('lang');
                        console.log(data);
                        t.langData.push(data);

                    }
                });
        },
        updateLang(dataa) {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Language/UpdateLang',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(dataa),
                    success: function (data) {
                        console.log(data);

                    }
                })
        },
        deleteLang(dataa) {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Language/DeleteLanguage',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(dataa),
                    success: function (data) {
                        console.log(data);
                        t.langData.splice(t.langData.indexOf(dataa), 1);
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
                    data: JSON.stringify(t.courseData),
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        console.log("Course");
                        console.log(data);
                        t.courseData = data;
                        //t.userInfo = data;

                    }
                })
        },
        AddNewCourse() {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Courses/addNewCourses',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(t.addCourse),
                    success: function (data) {
                        console.log('Course');
                        console.log(data);
                        t.courseData.push(data);

                    }
                });
        },
        updateCourse(dataa) {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Courses/UpdateCourses',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(dataa),
                    success: function (data) {
                        console.log(data);

                    }
                })
        },
        deleteCourse(dataa) {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Courses/DeleteCourses',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(dataa),
                    success: function (data) {
                        console.log(data);
                        t.courseData.splice(t.courseData.indexOf(dataa), 1);
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
                    data: JSON.stringify(t.certData),
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        console.log("Certificates");
                        console.log(data);
                        t.certData = data;
                        //t.userInfo = data;

                    }
                })
        },
        AddNewCert() {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Certificates/addNewCertificates',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(t.addCert),
                    success: function (data) {
                        console.log('cert');
                        console.log(data);
                        t.certData.push(data);

                    }
                });
        },
        updateCert(dataa) {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Certificates/UpdateCertificates',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(dataa),
                    success: function (data) {
                        console.log(data);

                    }
                })
        },
        deleteCert(dataa) {
            var t = this;
            $.ajax
                ({
                    type: 'POST',
                    url: '/Certificates/DeleteCertificates',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(dataa),
                    success: function (data) {
                        console.log(data);
                        t.certData.splice(t.certData.indexOf(dataa), 1);
                    }
                })
        },
        // End Certificates
    }
});
