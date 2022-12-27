
jQuery(document).ready(function () {

    jQuery(".owl-home-slider").owlCarousel({
        loop: true,
        center:true,
        items:1,
        smartSpeed: 600,
        lazyLoad: true,
        nav: false,
        dots: true,
        rtl: true,
        autoHeight:true,
        autoplay: true,
        autoplayTimeout: 6000,
        responsive: {
            0: {
                items: 1,
            },
            425: {
                    items: 1,
            },
            992: {
                items: 1,
                margin:15,
            },
            1025: {
                items: 1,
                margin:10,
            },
            1100: {
                items: 1,
                margin:30,
            },
        }
    });
});

jQuery(document).ready(function () {
    jQuery(".owl-suggested-screen").owlCarousel({
        loop: true,
        center: false,
        lazyLoad: true,
        items:1,
        smartSpeed: 600,
        margin:18,
        nav: true,
        //navText: ["<i class='angle-prev'>", "<i class='angle-next'>"],
        dots: false,
        rtl: true,
        autoplay: false,
        autoplayTimeout: 6000,

        responsive: {
            0: {
                items: 2.5,
            },
            425: {
                items: 3.5,
            },

            625: {
                items: 4.5,
            },

            1025: {
                items: 5.5,
                margin:10,
            },
            1100: {
                items: 6.5,
                margin:30,
            },
        }
    });
});


jQuery(document).ready(function () {
    jQuery(".owl-feedback-screen").owlCarousel({
        loop: true,
        center:false,
        items: 1,
        lazyLoad: true,
        smartSpeed: 600,
        margin:18,
        nav: true,
        //navText: ["<i class='angle-prev'>", "<i class='angle-next'>"],
        dots: false,
        rtl: true,
        autoplay: false,
        autoplayTimeout: 6000,
        responsive: {
            0: {
                items: 1.3,
            },
            425: {
                items: 2.5,
            },
            768: {
                items: 3.5,
                margin:15,
            },
            1025: {
                items: 3.5,
                margin:10,
            },
            1100: {
                items: 4.5,
                margin:15,
            },
        }
    });
});


jQuery(document).ready(function () {
    jQuery(".owl-kids-teenager").owlCarousel({
        loop: true,
        center:false,
        items:1,
        smartSpeed: 600,
        margin: 18,
        lazyLoad: true,
        nav: true,
        //navText: ["<i class='angle-prev'>", "<i class='angle-next'>"],
        dots: false,
        rtl: true,
        autoplay: false,
        autoplayTimeout: 6000,
        responsive: {
            0: {
                items: 2.5,
            },
            450: {
                items: 3.5,
            },
            550: {
                items: 4.5,
            },
            768: {
                items: 5.5,
                margin:15,
            },
            992: {
                items: 3,
                margin:10,
            },
            1100: {
                items: 4,
                margin:15,
            },
        }
    });
});


jQuery(document).ready(function () {
    jQuery(".owl-documentary").owlCarousel({
        loop: true,
        center:false,
        items:1,
        smartSpeed: 600,
        margin: 18,
        lazyLoad: true,
        nav: true,
        //navText: ["<i class='angle-prev'>", "<i class='angle-next'>"],
        dots: false,
        rtl: true,
        autoplay: false,
        autoplayTimeout: 6000,
        responsive: {
            0: {
                items: 2.5,
            },
            450: {
                items: 3.5,
            },
            992: {
                items: 3,
                margin:10,
            },
            1100: {
                items: 4,
                margin:15,
            },
        }
    });
});


jQuery(document).ready(function () {
    jQuery(".owl-gallery-slider").owlCarousel({
        loop: true,
        center:false,
        items:1,
        smartSpeed: 600,
        margin:18,
        nav: false,
        lazyLoad: true,
        //navText: ["<i class='angle-prev'>", "<i class='angle-next'>"],
        dots: false,
        rtl: true,
        autoplay: false,
        autoplayTimeout: 6000,
        responsive: {
            0: {
                items: 1.3,
            },
            425: {
                items: 2.5,
            },
            768: {
                items: 3.5,
                margin:15,
            },
            1025: {
                items: 3.2,
                margin:10,
            },
            1100: {
                items: 3.2,
                margin:15,
            },
        }
    });
});


jQuery(document).ready(function () {
    jQuery(".owl-movies-slider").owlCarousel({
        loop: true,
        center:true,
        items:1,
        smartSpeed: 600,
        margin:18,
        nav: false,
        dots: true,
        lazyLoad: true,
        rtl: true,
        autoHeight:false,
        autoplay: false,
        autoplayTimeout: 6000,
    });
});


jQuery(document).ready(function () {
    jQuery(".owl-people-screen").owlCarousel({
        loop: true,
        center:false,
        items:1,
        smartSpeed: 600,
        margin:18,
        nav: true,
        lazyLoad: true,
        //navText: ["<i class='angle-prev'>", "<i class='angle-next'>"],
        dots: false,
        rtl: true,
        autoplay: false,
        autoplayTimeout: 6000,
        responsive: {
            0: {
                items: 1,
            },
            600: {
                items: 2,
            },
            850: {
                items: 3,
                margin:10,
            },
            1200: {
                items: 4,
                margin:15,
            },
        }
    });
});


jQuery(document).ready(function () {
    jQuery(".owl-related-movies").owlCarousel({
        loop: false,
        center:false,
        items:1,
        smartSpeed: 600,
        margin: 18, 
        lazyLoad: true,
        nav: true,
       // navText: ["<i class='angle-prev'>", "<i class='angle-next'>"],
        dots: false,
        rtl: true,
        autoplay: false,
        autoplayTimeout: 6000,
        responsive: {
            0: {
                items: 2.5,
            },
            425: {
                items: 3.5,
            },

            625: {
                items: 4.5,
            },

            1025: {
                items: 5.5,
                margin:10,
            },
            1100: {
                items: 6.5,
                margin:30,
            },
        }
    });
});

jQuery(document).ready(function () {
    jQuery(".owl-movie-detail-images").owlCarousel({
        loop: false,
        center: false,
        items: 1,
        smartSpeed: 600,
        margin: 18,
        lazyLoad: true,
        nav: true,
        // navText: ["<i class='angle-prev'>", "<i class='angle-next'>"],
        dots: false,
        rtl: true,
        autoplay: false,
        autoplayTimeout: 6000,
        responsive: {
            0: {
                items: 1,
            },
            425: {
                items: 1,
            },

            625: {
                items: 2,
            },

            1025: {
                items: 3,
                margin: 10,
            },
            1100: {
                items: 4,
                margin: 30,
            },
        }
    });
});

jQuery(document).ready(function () {

    $("#movie-details-tabs li").click(function(){
        $("#movie-details-tabs li").removeClass('active');
        $("#movie-details-tabs li a span").addClass('d-none');
        $( this ).addClass( 'active' );
        $(this).find("a span").removeClass('d-none');
    });

    $("#advertising-tabs li").click(function(){
        $("#advertising-tabs li").removeClass('active');
        $( this ).addClass( 'active' );
    });

    $("#loginSignupForm .tab .nav-tabs li").click(function(){
        $("#loginSignupForm .tab .nav-tabs li").removeClass('active');
        $( this ).addClass( 'active' );
    });

});

//change numbers to persian numbers
//$(document).ready(function(){
//    persian={0:'۰',1:'۱',2:'۲',3:'۳',4:'۴',5:'۵',6:'۶',7:'۷',8:'۸',9:'۹'};
//    function traverse(el){
//        if(el.nodeType==3){
//            var list=el.data.match(/[0-9]/g);
//            if(list!=null && list.length!=0){
//                for(var i=0;i<list.length;i++)
//                    el.data=el.data.replace(list[i],persian[list[i]]);
//            }
//        }
//        for(var i=0;i<el.childNodes.length;i++){
//            traverse(el.childNodes[i]);
//        }
//    }
//    traverse(document.body);
//});


//get browser width
$(window).on('resize', function() {
    var browserWidth = $( window ).width();
    if(browserWidth <= 576){
        $(".movie-details .col-md-8").removeClass('d-flex');
    }else if(browserWidth > 576){
        $(".movie-details .col-md-8").addClass('d-flex');
    }

});

jQuery(document).ready(function ($) {

    /***********
Making placeholder star specifically red
****************/


    $('.placeholder').click(function() {
        $(this).siblings('input').focus();
        $(this).siblings('textarea').focus();
    });
    $('.form-control').focus(function() {
        $(this).siblings('.placeholder').hide();
    });
    $('.form-control').blur(function() {
        var $this = $(this);
        if ($this.val().length == 0)
            $(this).siblings('.placeholder').show();
    });
    $('.form-control').blur();


    $('#postTypeName').hide();
    $('#postType').change(function(){
        if($('#postType').val() == 'otherPostType') {
            $('#postTypeName').show();
        } else {
            $('#postTypeName').hide();
        }
    });




    $("#stateName,#cityName, #ekranPlacetype, #postType").select2({
        dir: "rtl",
    });



    $('.ticket input[type="checkbox"]').on('change', function() {
        $('.ticket input[type="checkbox"]').not(this).prop('checked', false);
    });

    $("#ticketPriceValue").hide();
    $("#ticketPriceHelp").hide();
    $("#ticketCheckboxYes").click(function () {
        if ($(this).is(":checked")) {
            $("#ticketPriceValue").show(500);
            $("#ticketPriceHelp").show(500);
        } else {
            $("#ticketPriceValue").hide(500);
            $("#ticketPriceHelp").hide(500);
        }
    });
    $("#ticketCheckboxNo").click(function () {
        if ($(this).is(":checked")) {
            $("#ticketPriceValue").hide(500);
            $("#ticketPriceHelp").hide(500);
        }
    });


});

$("#outputAddress").hide();

function switchLeft(){

    var switchBtnRight 			= document.querySelector('.switch-button-case.right');
    var switchBtnLeft 			= document.querySelector('.switch-button-case.left');
    var activeSwitch 			= document.querySelector('#activeToggle');

    switchBtnRight.classList.remove('active-case');
    switchBtnLeft.classList.add('active-case');
    activeSwitch.style.right = '50%';

    $("#outputAddress").show(500);
    $("#iranAddress").hide(500);

}

function switchRight(){

    var switchBtnRight 			= document.querySelector('.switch-button-case.right');
    var switchBtnLeft 			= document.querySelector('.switch-button-case.left');
    var activeSwitch 			= document.querySelector('#activeToggle');

    switchBtnRight.classList.add('active-case');
    switchBtnLeft.classList.remove('active-case');
    activeSwitch.style.right = '0%';

    $("#outputAddress").hide(500);
    $("#iranAddress").show(500);

}

// error_rule_link (tab click)
$('.about_rule_link').click(function (e) {
    e.preventDefault();

    $('.about_trafic_tab').addClass('d-none');
    $('.about_rule_tab').removeClass('d-none');

    $(this).addClass('active');
    $('.about_trafic_link').removeClass('active');

    $(this).parent().addClass('flesh-up');
    $('.about_trafic_link').parent().removeClass('flesh-up');
});


//aboutUs page
$('a[href^="#c_"]').click(function (e) {
    e.preventDefault();
    var id = $(this).attr('href');
    let idArray = id.split("_");
    /*$('[id^="c_"]').addClass('d-none');*/
    $('#p_' + idArray[2] + ' [id^="c_"]').addClass('d-none');
    $('#p_' + idArray[2] + ' a[href ^= "#c_"]').parent().removeClass('flesh-up');
    $(this).parent().addClass('flesh-up');

    let tab = "c_" + idArray[1];
    $('#p_' + idArray[2] + ' [id ="' + tab+'"]').removeClass('d-none');
});