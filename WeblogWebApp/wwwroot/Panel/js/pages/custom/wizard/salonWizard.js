"use strict";

// Class definition
var KTWizard3 = function () {
    // Base elements
    var _wizardEl;
    var _formEl;
    var _wizard;
    var _validations = [];

    // Private functions
    var initWizard = function () {
        // Initialize form wizard
        _wizard = new KTWizard(_wizardEl, {
            startStep: 1, // initial active step number
            clickableSteps: true  // allow step clicking
        });

        // Validation before going to next page
        _wizard.on('beforeNext', function (wizard) {
            // Don't go to the next step yet
            if (wizard.getStep() > wizard.getNewStep()) {
                return; // Skip if stepped back
            }


            // Validate form
            var validator = _validations[wizard.getStep() - 1]; // get validator for currnt step
            validator.validate().then(function (status) {
                if (status == 'Valid') {
                    wizard.goTo(wizard.getNewStep());
                    KTUtil.scrollTop();
                } else {
                    Swal.fire({
                        text: "با عرض پوزش ، به نظر می رسد برخی از خطاها شناسایی شده اند ، لطفا دوباره امتحان کنید.",
                        type: "error",
                        buttonsStyling: false,
                        confirmButtonText: "باشه فهمیدم!",
                        customClass: {
                            confirmButton: "btn font-weight-bold btn-light"
                        }
                    }).then(function () {
                        KTUtil.scrollTop();
                    });
                }
            });
        });



        // Change event
        _wizard.on('change', function (wizard) {
            KTUtil.scrollTop();
        });




        _wizard.on('submit', async function (wizard) {

            var allvalid = [];

            for (let i = 1; i <= wizard.totalSteps; i++) {

                var validation = _validations[i - 1];

                var status = await validation.validate();


                if (status === 'Invalid') {
                    allvalid[i] = false;
                } else {
                    allvalid[i] = true;
                }

            }
            if (allvalid.every(x => x === true)) {
                SubmitSalonForm("");
            } else {
                Swal.fire({
                    text: "با عرض پوزش ، به نظر می رسد برخی از خطاها شناسایی شده اند ، لطفا دوباره امتحان کنید.",
                    type: "error",
                    buttonsStyling: false,
                    confirmButtonText: "باشه فهمیدم!",
                    customClass: {
                        confirmButton: "btn font-weight-bold btn-light"
                    }
                }).then(function () {
                    KTUtil.scrollTop();
                });
            }

        });
    }

    var initValidation = function () {
        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        // Step 1
        _validations.push(FormValidation.formValidation(
            _formEl,
            {
                fields: {
                    SalonName: {
                        validators: {
                            notEmpty: {
                                message: "نام سالن الزامی است"
                            }
                        }
                    },
                    SalonOwnerOrgan: {
                        validators: {
                            notEmpty: {
                                message: "وارد کردن ارگان مالک سینما الزامی است"
                            }

                        }
                    },
                    ChairsCount: {
                        validators: {
                            notEmpty: {
                                message: "وارد کردن تعداد صندلی ها الزامی است"
                            },
                            digits: {
                                message: 'مقدار وارد شده معتبر نیست'
                            },
                            lessThan: {
                                max: 100000,
                                message: `مقدار وارد شده نباید بیش از 100000  باشد`
                            },
                            greaterThan: {
                                min: 1,
                                message: 'مقدار وارد شده نباید کم تر از 1 باشد'
                            }

                        }
                    },
                    OwnerShipType: {
                        validators: {
                            notEmpty: {
                                message: "وارد کردن نوع مالک الزامی است"
                            }
                        }
                    },
                    Area: {
                        validators: {
                            digits: {
                                message: 'مقدار وارد شده معتبر نیست'
                            },
                            lessThan: {
                                max: 1000000,
                                message: `مقدار وارد شده نباید بیش از 1000000 متر باشد`
                            },
                            greaterThan: {
                                min: 1,
                                message: 'مقدار وارد شده نباید کم تر از 1 باشد'
                            }

                        }
                    },
                    OwnerPhoneNumber: {
                        validators: {
                            regexp: {
                                regexp: /^09\d{9}$/,
                                message: `مقدار وارد شده معتبر نیست`
                            }

                        }
                    },
                    SalonPhoneNumber: {
                        validators: {
                            digits: {
                                message: 'مقدار وارد شده معتبر نیست'
                            },
                            regexp: {
                                regexp: /^0\d{2,3}\d{8}$/g,
                                message: `شماره تلفن معتبر نیست`
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        ));

        // Step 2
        _validations.push(FormValidation.formValidation(
            _formEl,
            {
                fields: {
                    BandsCount: {
                        validators: {
                            digits: {
                                message: 'مقدار وارد شده معتبر نیست'
                            },
                            lessThan: {
                                max: 100,
                                message: `مقدار وارد شده نباید بیش از 100  باشد`
                            },
                            greaterThan: {
                                min: 1,
                                message: 'مقدار وارد شده نباید کم تر از 1 باشد'
                            }

                        }
                    },
                    ScreenWidth: {
                        validators: {
                            digits: {
                                message: 'مقدار وارد شده معتبر نیست'
                            },
                            lessThan: {
                                max: 100,
                                message: `مقدار وارد شده نباید بیش از 100  باشد`
                            },
                            greaterThan: {
                                min: 1,
                                message: 'مقدار وارد شده نباید کم تر از 1 باشد'
                            }

                        }
                    },
                    ScreenHeight: {
                        validators: {
                            digits: {
                                message: 'مقدار وارد شده معتبر نیست'
                            },
                            lessThan: {
                                max: 100,
                                message: `مقدار وارد شده نباید بیش از 100  باشد`
                            },
                            greaterThan: {
                                min: 1,
                                message: 'مقدار وارد شده نباید کم تر از 1 باشد'
                            }

                        }
                    },
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        ));

        // Step 3
        _validations.push(FormValidation.formValidation(
            _formEl,
            {
                fields: {

                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        ));

        // Step 4

        _validations.push(FormValidation.formValidation(
            _formEl,
            {
                fields: {
                    SuggestedPrice: {
                        validators: {
                            digits: {
                                message: 'مقدار وارد شده معتبر نیست'
                            },
                            lessThan: {
                                max: 200000,
                                message: `مقدار وارد شده نباید بیش از 200000  باشد`
                            },
                            greaterThan: {
                                min: 1,
                                message: 'مقدار وارد شده نباید کم تر از 1 باشد'
                            }

                        }
                    },
                    EstimateViewers: {
                        validators: {
                            digits: {
                                message: 'مقدار وارد شده معتبر نیست'
                            },
                            lessThan: {
                                max: 1000000,
                                message: `مقدار وارد شده نباید بیش از 1000000  باشد`
                            },
                            greaterThan: {
                                min: 1,
                                message: 'مقدار وارد شده نباید کم تر از 1 باشد'
                            }

                        }
                    }
                    , NormalDayStartTime: {
                        validators: {
                            notEmpty: {
                                message: 'پر کردن این فیلد لازم است'
                            }
                        }
                    }
                    , NormalDayEndTime: {
                        validators: {
                            notEmpty: {
                                message: 'پر کردن این فیلد لازم است'
                            }
                            //regexp: {
                            //                         regexp: /^\d{[0-2],[0-4]}:\d{2}$/gm,
                            //                         message: `ساعت وارد شده معتبر نمی باشد`
                            //                     }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        ));
        // Step 5
        _validations.push(FormValidation.formValidation(
            _formEl,
            {
                fields: {
                    headerImages: {
                        validators: {
                            notEmpty: {
                                message: "وارد کردن حداقل یک عکس از سر در سالن الزامی است"
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        ));
    }

    return {
        // public functions
        init: function () {
            _wizardEl = KTUtil.getById('kt_wizard_v3');
            _formEl = KTUtil.getById('kt_form');

            initWizard();
            initValidation();
        }
    };
}();

jQuery(document).ready(function () {
    KTWizard3.init();
});
