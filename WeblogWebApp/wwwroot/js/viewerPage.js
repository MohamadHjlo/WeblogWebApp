//this snipet set scrollbar option
(function ($) {
    $('.chat-content, .screen').mCustomScrollbar({
        setHeight: 400,
        theme: 'dark-3',
        autoHideScrollbar: false,
        autoExpandScrollbar: false,
        mouseWheel: {
            enable: true,
        },
        scrollButtons: {
            enable: false,
        },
        keyboard: {
            enable: true,
        },
        contentTouchScroll: 25,
    });
})(jQuery);


//this snipet toggle(show/hide) tabs
//chat DOM Elements
const tabs = document.querySelectorAll('#tabs .tab');
const tabContents = document.querySelectorAll('#tabs .tabcontent');
const tabsImage = document.querySelectorAll('#tabs .tabs .TabImage');

// Functions active different tabs content
const activateTab = tabnum => {
    tabs.forEach(tab => {
        tab.classList.remove('active');
    });

    tabContents.forEach(tabContent => {
        tabContent.classList.remove('active');
    });

    document.querySelector('#tab' + tabnum).classList.add('active');
    document.querySelector('#tabcontent' + tabnum).classList.add('active');

    const removeActiveWordFromImageSrc = function (imageSrc) {
        return imageSrc.replace("-active", "");
    }
    tabsImage.forEach(img => {
        img.src = removeActiveWordFromImageSrc(img.src);
    });

    let imageSrc = document.querySelector('#tab' + tabnum + ' img').src;
    //change color image when tab become active
    let splitByLastDot = function (src) {
        var index = src.lastIndexOf('.');
        return [src.slice(0, index), src.slice(index + 1)]
    }
    let splitedSrcArray = splitByLastDot(imageSrc);
    document.querySelector('#tab' + tabnum + ' img').src = splitedSrcArray[0] + '-active.' + splitedSrcArray[1];

};

// Event Listeners
tabs.forEach(tab => {
    tab.addEventListener('click', () => {
        activateTab(tab.dataset.tab);
    });
});

// this snipet is used for login and sinup modal
const formTabs = document.querySelectorAll('#viewersLoginSignupForm .tab');
const formTabsContent = document.querySelectorAll('#viewersLoginSignupForm .tab-pane');
formTabs.forEach(tab => {
    tab.addEventListener('click', () => {
        formTabs.forEach(allTabs => {
            allTabs.classList.remove('active');
        });
        tab.classList.add('active');
        let tabNum = tab.dataset.tab;
        formTabsContent.forEach(allTabsContent => {
            let TabsContentNum = allTabsContent.dataset.tab;
            TabsContentNum == tabNum ? allTabsContent.classList.add('active') : allTabsContent.classList.remove('active');
        });
    });
});


//this snipet hide vip user division
const vipUserCloseBtn = document.querySelectorAll('.vip-user .icon .close');
vipUserCloseBtn.forEach(item => {
    item.addEventListener('click', () => {
        const vipUserDiv = item.closest('.vip-user');
        vipUserDiv.classList.add('u-hide');
    });
});


//this snipet toggle(show/hide) menubar
const navigationOpenIcon = document.querySelector('.mobile-menu');
const navigationCloseIcon = document.querySelector('.close-container');
const navigationNav = document.querySelector('.wrapper');
// const navigationCloseIcon = document.querySelector('.navigation .navigation-button');

navigationOpenIcon.addEventListener('click',
    () => {
        navigationNav.classList.add('show-mobile-menu');
    });

navigationCloseIcon.addEventListener('click', () => {
    navigationNav.classList.remove('show-mobile-menu');
});


//this snipet is for unsupperted browser
function get_browser() {
    var ua = navigator.userAgent, tem, M = ua.match(/(opera|chrome|safari|firefox|msie|trident(?=\/))\/?\s*(\d+)/i) || [];
    if (/trident/i.test(M[1])) {
        tem = /\brv[ :]+(\d+)/g.exec(ua) || [];
        return { name: 'IE', version: (tem[1] || '') };
    }
    if (M[1] === 'Chrome') {
        tem = ua.match(/\bOPR\/(\d+)/)
        if (tem != null) { return { name: 'Opera', version: tem[1] }; }
    }
    if (window.navigator.userAgent.indexOf("Edge") > -1) {
        tem = ua.match(/\Edge\/(\d+)/)
        if (tem != null) { return { name: 'Edge', version: tem[1] }; }
    }
    M = M[2] ? [M[1], M[2]] : [navigator.appName, navigator.appVersion, '-?'];
    if ((tem = ua.match(/version\/(\d+)/i)) != null) { M.splice(1, 1, tem[1]); }
    return {
        name: M[0],
        version: +M[1]
    };
}

var browser = get_browser();
var isSupported = isSupported(browser);

function isSupported(browser) {
    var supported = false;
    if (browser.name === "Chrome" && browser.version >= 75) {
        supported = true;
    } else if ((browser.name === "MSIE" || browser.name === "IE") && browser.version >= 10) {
        supported = true;
    } else if (browser.name === "Edge") {
        supported = true;
    } else if (browser.name === "Firefox" && browser.version >= 80) {
        supported = true;
    }

    return supported;
}


// در صورتی که کوکی کاربر غیر فعال باشد پیامی مبنی بر فعال کردن کوکی به کاربر نشان می دهد
function are_cookies_enabled() {
    var cookieEnabled = (navigator.cookieEnabled) ? true : false;

    if (typeof navigator.cookieEnabled == "undefined" && !cookieEnabled) {
        document.cookie = "testcookie";
        cookieEnabled = (document.cookie.indexOf("testcookie") != -1) ? true : false;
    }

    setTimeout(function () {

        if (!cookieEnabled) {
            $("#ekranModal").modal();
            $("#ekranModalTitle").html("بیننده گرامی لطفا به منظور استفاده بهتر از سامانه اکران مردمی آنلاین کوکی های مرورگر خود را فعال کنید");
            $("#ekranModalBody").empty();
        }

    }, 3000);
}

are_cookies_enabled();


$(function () {
    function runLike() {
        var rand = Math.floor((Math.random() * 100) + 1);
        var flows = ["flowOne", "flowTwo", "flowThree"];
        var colors = ["like-1", "like-2", "like-3", "like-4", "like-5", "like-6"];
        var timing = (Math.random() * (2.5 - 1.0) + 1.0).toFixed(1);
        // Animate Particle

        $('<div class="particle part-' + rand + ' ' + colors[Math.floor((Math.random() * 6))] + '" style="font-size:' + Math.floor(Math.random() * (40 - 22) + 22) + 'px;"><svg id="Layer_1" data-name="Layer 1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 569.14 546.73"><defs><style>.cls-1{opacity:0.5;}.cls-2{fill:#00e100;}</style></defs><g class="cls-1"><path class="cls-2" d="M569,317.8v18.89c-.88.15-1.06.81-1.24,1.56C564,353.35,555.57,365,542,372.77c-2.48,1.41-1.53,2.67-.88,4.45,9.74,26.36,1.62,51.12-21.82,66.06-2.62,1.67-2.93,2.84-1.72,5.63a50,50,0,0,1,3.12,29.39c-4.91,26.15-27.05,43.89-54.9,43.94q-108.06.13-216.11,0c-19.09,0-37.28-4.75-55-11.72-3.94-1.55-5-3.53-5-7.65q.21-116.4.12-232.76c0-7.49.71-14.29,4.3-21.74,22.18-46.05,43.23-92.65,64.72-139A23.23,23.23,0,0,0,261,99.23c-.1-23.89.09-47.79-.15-71.67-.06-6.62,2.12-11.34,7.8-14.75A88.54,88.54,0,0,1,295.15,2c3.11-.67,6.6.27,9.37-2H309c9.29,2.16,18.29,5,26,11,28.59,22.22,44.66,50.9,44.19,87.63-.37,29-7.94,56.62-16.19,84.11-2.28,7.6-2.38,7.57,5.26,7.57q68.34,0,136.67,0c29.11.06,52.77,16.29,61.35,41.59,1,3,.9,6.45,2.82,9.22V258.9c-3,8.59-4.94,17.79-11.12,24.79-3.79,4.29-3.76,7.06.18,11.14C564.17,301.16,566,309.85,569,317.8Z" transform="translate(0.07 0)"/><path class="cls-2" d="M0,286.68c2-1,1.59-3.18,2-4.8,6.86-25.5,29.6-43.74,56-44,34.6-.31,69.21,0,103.81-.2,3.67,0,4.1,1.26,4.1,4.42q-.12,144,0,288.08a6.48,6.48,0,0,1-3.44,6.23,60,60,0,0,1-26.41,9.19c-1,.09-2.3-.45-2.73,1.09h-2.22c-.71-1.27-1.93-.82-3-.82H59c-.89,0-1.86-.24-2.35.86H53.27c-.81-2.08-2.84-1.33-4.27-1.64-24.78-5.37-40.53-20.24-47.46-44.6-.36-1.25.25-3.1-1.61-3.77Z" transform="translate(0.07 0)"/></g></svg></div>').appendTo('.particle-box').css({ animation: "" + flows[Math.floor((Math.random() * 3))] + " " + timing + "s linear" });
        $('.part-' + rand).show();

        // Remove Particle
        setTimeout(function () {
            $('.part-' + rand).remove();
        }, timing * 1000 - 100);
    };

    $('.like').on('click', function () {
        runLike();
    });

    function runDislike() {
        var rand = Math.floor((Math.random() * 100) + 1);
        var flows = ["flowOne", "flowTwo", "flowThree"];
        var colors = ["like-1", "like-2", "like-3", "like-4", "like-5", "like-6"];
        var timing = (Math.random() * (2.5 - 1.0) + 1.0).toFixed(1);
        // Animate Particle

        $('<div class="particle part-' + rand + ' ' + colors[Math.floor((Math.random() * 6))] + '" style="font-size:' + Math.floor(Math.random() * (40 - 22) + 22) + 'px;"><svg id="Layer_1" data-name="Layer 1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 569.14 546.73"><defs><style>.cls-1{opacity:0.5;}.cls-2{fill:red;}</style></defs><g class="cls-1"><path class="cls-2" d="M0,228.94V210.05c.88-.15,1.06-.81,1.24-1.56C5,193.39,13.43,181.7,27,174c2.48-1.41,1.53-2.68.88-4.46-9.74-26.35-1.62-51.11,21.82-66.06,2.62-1.67,2.93-2.83,1.72-5.63a49.94,49.94,0,0,1-3.12-29.39c4.91-26.15,27.05-43.89,54.9-43.93q108.06-.13,216.11,0c19.09,0,37.28,4.75,55,11.72,3.94,1.55,5,3.53,5,7.65q-.21,116.4-.12,232.76c0,7.49-.71,14.29-4.3,21.74-22.18,46.05-43.23,92.65-64.72,139A23.23,23.23,0,0,0,308,447.51c.1,23.89-.09,47.78.15,71.66.06,6.62-2.12,11.35-7.8,14.75a88,88,0,0,1-26.54,10.81c-3.11.68-6.6-.26-9.37,2H260c-9.29-2.15-18.29-5-26-11-28.59-22.21-44.66-50.89-44.19-87.63.37-28.94,7.94-56.62,16.19-84.1,2.28-7.6,2.38-7.57-5.26-7.57q-68.34,0-136.67,0C35,356.37,11.33,340.14,2.75,314.84c-1-3-.9-6.45-2.82-9.22V287.84c3-8.59,4.94-17.8,11.12-24.79,3.79-4.29,3.76-7.06-.18-11.14C4.83,245.58,3.05,236.89,0,228.94Z" transform="translate(0.07 0)"/><path class="cls-2" d="M569,260.06c-2,1-1.59,3.17-2,4.8-6.86,25.5-29.6,43.74-56,44-34.6.31-69.21,0-103.81.2-3.67,0-4.1-1.26-4.1-4.42q.12-144,0-288.08a6.48,6.48,0,0,1,3.44-6.23,60.13,60.13,0,0,1,26.41-9.2c1-.09,2.3.46,2.73-1.09h2.22c.71,1.27,1.93.82,3,.82H510c.89,0,1.86.24,2.35-.86h3.34c.81,2.09,2.84,1.33,4.27,1.64,24.78,5.37,40.53,20.24,47.46,44.6.36,1.26-.25,3.1,1.61,3.77Z" transform="translate(0.07 0)"/></g></svg></div>').appendTo('.particle-box').css({ animation: "" + flows[Math.floor((Math.random() * 3))] + " " + timing + "s linear" });
        $('.part-' + rand).show();

        // Remove Particle
        setTimeout(function () {
            $('.part-' + rand).remove();
        }, timing * 1000 - 100);
    };

    $('.dislike').on('click', function () {
        runDislike();
    });
});


//حذف تگ های اچ تی ام ال
function escapeHtml(str) {
    const map =
    {
        '&': '&amp;',
        '<': '&lt;',
        '>': '&gt;',
        '"': '&quot;',
        "'": '&EkranOnlineUtility39;',
        '/': '&#x2F;',
        '`': '&#x60;',
        '=': '&#x3D;'
    };
    return str.replace(/[&<>"'`=\/]/g, function (m) { return map[m]; });
}


function isEmpty(str) {
    return (!str || str.length === 0);
}

function toEnglishNumber(strNum) {
    var pn = ["۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹"];
    var en = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];

    var replaceString  = strNum;
    for (var i = 0; i < pn.length; i++) {
        var regexFa = new RegExp(pn[i], 'g');
        replaceString = replaceString.replace(regexFa, en[i]);
    }
    return replaceString;
}

function isNumber(str) {
    var pattern = /^[۰۱۲۳۴۵۶۷۸۹0-9]+$/;
    return pattern.test(str);  // returns a boolean
}
