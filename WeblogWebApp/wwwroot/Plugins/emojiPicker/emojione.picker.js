/*
 * jQuery EmojiOne Textarea Picker
 *
 * This a lightweight ( 29.2 KB ) plugin that adds an emojiOne emoji picker to a textarea.
 * You can choose to send the shortcode ( eg: :smiley: ) or the unicode ( ☺ ) to the textarea.
 *
 * https://github.com/twizdev/jquery-emojione-textarea-picker
 *
 * Copyright 2017, TwizDev
 *
 * Licensed under the MIT license:
 * https://opensource.org/licenses/MIT
 */

(function ( $ ) {
     $.fn.emojionePicker = function( options ) {
		 var emojiContainer = "emojionepicker",
		     activeEl;

		// DEFAULT SETTINGS
        var settings = $.extend({
			pickerTop       : 5, 		// Picker top margin
			pickerRight     : 5, 		// Picker right margin
			type		: "shortcode",  // What to send to textarea, valid values are "shortcode" and "unicode"

        }, options );

		var $el = this;

		// EMOJI LIST
		var emojiList = {
			people: {
				header: ":smiley:",
				content: ":grinning: :grin: :joy: :rofl: :smiley: :smile: :sweat_smile: :laughing: :wink: :blush: :yum: :sunglasses: :heart_eyes: :kissing_heart: :kissing: :kissing_smiling_eyes: :kissing_closed_eyes: :relaxed: :slight_smile: :hugging: :thinking: :neutral_face: :expressionless: :no_mouth: :rolling_eyes: :smirk: :persevere: :disappointed_relieved: :open_mouth: :zipper_mouth: :hushed: :sleepy: :tired_face: :sleeping: :relieved: :nerd: :stuck_out_tongue: :stuck_out_tongue_winking_eye: :stuck_out_tongue_closed_eyes: :drooling_face: :unamused: :sweat: :pensive: :confused: :upside_down: :money_mouth: :astonished: :frowning2: :slight_frown: :confounded: :disappointed: :worried: :triumph: :cry: :sob: :frowning: :anguished: :fearful: :weary: :grimacing: :cold_sweat: :scream: :flushed: :dizzy_face: :rage: :angry: :innocent: :cowboy:".split( " " )
			}/*,
			nature: {
				header: ":four_leaf_clover:",
				content: ":see_no_evil: :hear_no_evil: :speak_no_evil: :sweat_drops: :dash: :monkey_face: :monkey: :gorilla: :dog: :dog2: :poodle: :wolf: :fox: :cat: :cat2: :lion_face: :tiger: :tiger2: :leopard: :horse: :racehorse: :deer: :unicorn: :cow: :ox: :water_buffalo: :cow2: :pig: :pig2: :boar: :pig_nose: :ram: :sheep: :goat: :dromedary_camel: :camel: :elephant: :rhino: :mouse: :mouse2: :rat: :hamster: :rabbit: :rabbit2: :chipmunk: :bat: :bear: :koala: :panda_face: :feet: :turkey: :chicken: :rooster: :hatching_chick: :baby_chick: :hatched_chick: :bird: :penguin: :dove: :eagle: :duck: :owl: :frog: :crocodile: :turtle: :lizard: :snake: :dragon_face: :dragon: :whale: :whale2: :dolphin: :fish: :tropical_fish: :blowfish: :shark: :octopus: :shell: :crab: :shrimp: :squid: :butterfly: :snail: :bug: :ant: :bee: :beetle: :spider: :spider_web: :scorpion: :bouquet: :cherry_blossom: :rosette: :rose: :wilted_rose: :hibiscus: :sunflower: :blossom: :tulip: :seedling: :evergreen_tree: :deciduous_tree: :palm_tree: :cactus: :ear_of_rice: :herb: :shamrock: :four_leaf_clover: :maple_leaf: :fallen_leaf: :leaves: :mushroom: :chestnut: :earth_africa: :earth_americas: :earth_asia: :new_moon: :waxing_crescent_moon: :first_quarter_moon: :waxing_gibbous_moon: :full_moon: :waning_gibbous_moon: :last_quarter_moon: :waning_crescent_moon: :crescent_moon: :new_moon_with_face: :first_quarter_moon_with_face: :last_quarter_moon_with_face: :sunny: :full_moon_with_face: :sun_with_face: :star: :star2: :cloud: :partly_sunny: :thunder_cloud_rain: :white_sun_small_cloud: :white_sun_cloud: :white_sun_rain_cloud: :cloud_rain: :cloud_snow: :cloud_lightning: :cloud_tornado: :fog: :wind_blowing_face: :umbrella2: :umbrella: :zap: :snowflake: :snowman2: :snowman: :comet: :fire: :droplet: :ocean: :jack_o_lantern: :christmas_tree: :sparkles: :tanabata_tree: :bamboo:".split( " " )
			},
			food: {
				header: ":hamburger:",
				content: ":grapes: :melon: :watermelon: :tangerine: :lemon: :banana: :pineapple: :apple: :green_apple: :pear: :peach: :cherries: :strawberry: :kiwi: :tomato: :avocado: :eggplant: :potato: :carrot: :corn: :hot_pepper: :cucumber: :peanuts: :bread: :croissant: :french_bread: :pancakes: :cheese: :meat_on_bone: :poultry_leg: :bacon: :hamburger: :fries: :pizza: :hotdog: :taco: :burrito: :stuffed_flatbread: :egg: :cooking: :shallow_pan_of_food: :stew: :salad: :popcorn: :bento: :rice_cracker: :rice_ball: :rice: :curry: :ramen: :spaghetti: :sweet_potato: :oden: :sushi: :fried_shrimp: :fish_cake: :dango: :icecream: :shaved_ice: :ice_cream: :doughnut: :cookie: :birthday: :cake: :chocolate_bar: :candy: :lollipop: :custard: :honey_pot: :baby_bottle: :milk: :coffee: :tea: :sake: :champagne: :wine_glass: :cocktail: :tropical_drink: :beer: :beers: :champagne_glass: :tumbler_glass: :fork_knife_plate: :fork_and_knife: :spoon:".split( " " )
			},
			objects: {
				header: ":bulb:",
				content: ":skull_crossbones: :love_letter: :bomb: :hole: :shopping_bags: :prayer_beads: :gem: :knife: :amphora: :map: :barber: :frame_photo: :bellhop: :door: :sleeping_accommodation: :bed: :couch: :toilet: :shower: :bathtub: :hourglass: :hourglass_flowing_sand: :watch: :alarm_clock: :stopwatch: :timer: :clock: :thermometer: :beach_umbrella: :balloon: :tada: :confetti_ball: :dolls: :flags: :wind_chime: :ribbon: :gift: :joystick: :postal_horn: :microphone2: :level_slider: :control_knobs: :radio: :iphone: :calling: :telephone: :telephone_receiver: :pager: :fax: :battery: :electric_plug: :computer: :desktop: :printer: :keyboard: :mouse_three_button: :trackball: :minidisc: :floppy_disk: :cd: :dvd: :movie_camera: :film_frames: :projector: :tv: :camera: :camera_with_flash: :video_camera: :vhs: :mag: :mag_right: :microscope: :telescope: :satellite: :candle: :bulb: :flashlight: :izakaya_lantern: :notebook_with_decorative_cover: :closed_book: :book: :green_book: :blue_book: :orange_book: :books: :notebook: :ledger: :page_with_curl: :scroll: :page_facing_up: :newspaper: :newspaper2: :bookmark_tabs: :bookmark: :label: :moneybag: :yen: :dollar: :euro: :pound: :money_with_wings: :credit_card: :envelope: :e-mail: :incoming_envelope: :envelope_with_arrow: :outbox_tray: :inbox_tray: :package: :mailbox: :mailbox_closed: :mailbox_with_mail: :mailbox_with_no_mail: :postbox: :ballot_box: :pencil2: :black_nib: :pen_fountain: :pen_ballpoint: :paintbrush: :crayon: :pencil: :file_folder: :open_file_folder: :dividers: :date: :calendar: :notepad_spiral: :calendar_spiral: :card_index: :chart_with_upwards_trend: :chart_with_downwards_trend: :bar_chart: :clipboard: :pushpin: :round_pushpin: :paperclip: :paperclips: :straight_ruler: :triangular_ruler: :scissors: :card_box: :file_cabinet: :wastebasket: :lock: :unlock: :lock_with_ink_pen: :closed_lock_with_key: :key: :key2: :hammer: :pick: :hammer_pick: :tools: :dagger: :crossed_swords: :gun: :shield: :wrench: :nut_and_bolt: :gear: :compression: :alembic: :scales: :link: :chains: :syringe: :pill: :smoking: :coffin: :urn: :moyai: :oil: :crystal_ball: :shopping_cart: :triangular_flag_on_post: :crossed_flags: :flag_black: :flag_white: :rainbow_flag:".split( " " )
			},
			activity: {
				header: ":football:",
				content: ":space_invader: :levitate: :fencer: :horse_racing: :horse_racing_tone1: :horse_racing_tone2: :horse_racing_tone3: :horse_racing_tone4: :horse_racing_tone5: :skier: :snowboarder: :golfer: :surfer: :surfer_tone1: :surfer_tone2: :surfer_tone3: :surfer_tone4: :surfer_tone5: :rowboat: :rowboat_tone1: :rowboat_tone2: :rowboat_tone3: :rowboat_tone4: :rowboat_tone5: :swimmer: :swimmer_tone1: :swimmer_tone2: :swimmer_tone3: :swimmer_tone4: :swimmer_tone5: :basketball_player: :basketball_player_tone1: :basketball_player_tone2: :basketball_player_tone3: :basketball_player_tone4: :basketball_player_tone5: :lifter: :lifter_tone1: :lifter_tone2: :lifter_tone3: :lifter_tone4: :lifter_tone5: :bicyclist: :bicyclist_tone1: :bicyclist_tone2: :bicyclist_tone3: :bicyclist_tone4: :bicyclist_tone5: :mountain_bicyclist: :mountain_bicyclist_tone1: :mountain_bicyclist_tone2: :mountain_bicyclist_tone3: :mountain_bicyclist_tone4: :mountain_bicyclist_tone5: :cartwheel: :cartwheel_tone1: :cartwheel_tone2: :cartwheel_tone3: :cartwheel_tone4: :cartwheel_tone5: :wrestlers: :wrestlers_tone1: :wrestlers_tone2: :wrestlers_tone3: :wrestlers_tone4: :wrestlers_tone5: :water_polo: :water_polo_tone1: :water_polo_tone2: :water_polo_tone3: :water_polo_tone4: :water_polo_tone5: :handball: :handball_tone1: :handball_tone2: :handball_tone3: :handball_tone4: :handball_tone5: :juggling: :juggling_tone1: :juggling_tone2: :juggling_tone3: :juggling_tone4: :juggling_tone5: :circus_tent: :performing_arts: :art: :slot_machine: :bath: :bath_tone1: :bath_tone2: :bath_tone3: :bath_tone4: :bath_tone5: :reminder_ribbon: :tickets: :ticket: :military_medal: :trophy: :medal: :first_place: :second_place: :third_place: :soccer: :baseball: :basketball: :volleyball: :football: :rugby_football: :tennis: :8ball: :bowling: :cricket: :field_hockey: :hockey: :ping_pong: :badminton: :boxing_glove: :martial_arts_uniform: :goal: :dart: :golf: :ice_skate: :fishing_pole_and_fish: :running_shirt_with_sash: :ski: :video_game: :game_die: :musical_score: :microphone: :headphones: :saxophone: :guitar: :musical_keyboard: :trumpet: :violin: :drum: :clapper: :bow_and_arrow:".split( " " )
			},
			travel: {
				header: ":red_car:",
				content: ":race_car: :motorcycle: :japan: :mountain_snow: :mountain: :volcano: :mount_fuji: :camping: :beach: :desert: :island: :park: :stadium: :classical_building: :construction_site: :homes: :cityscape: :house_abandoned: :house: :house_with_garden: :office: :post_office: :european_post_office: :hospital: :bank: :hotel: :love_hotel: :convenience_store: :school: :department_store: :factory: :japanese_castle: :european_castle: :wedding: :tokyo_tower: :statue_of_liberty: :church: :mosque: :synagogue: :shinto_shrine: :kaaba: :fountain: :tent: :foggy: :night_with_stars: :sunrise_over_mountains: :sunrise: :city_dusk: :city_sunset: :bridge_at_night: :milky_way: :carousel_horse: :ferris_wheel: :roller_coaster: :steam_locomotive: :railway_car: :bullettrain_side: :bullettrain_front: :train2: :metro: :light_rail: :station: :tram: :monorail: :mountain_railway: :train: :bus: :oncoming_bus: :trolleybus: :minibus: :ambulance: :fire_engine: :police_car: :oncoming_police_car: :taxi: :oncoming_taxi: :red_car: :oncoming_automobile: :blue_car: :truck: :articulated_lorry: :tractor: :bike: :scooter: :motor_scooter: :busstop: :motorway: :railway_track: :fuelpump: :rotating_light: :traffic_light: :vertical_traffic_light: :construction: :anchor: :sailboat: :canoe: :speedboat: :cruise_ship: :ferry: :motorboat: :ship: :airplane: :airplane_small: :airplane_departure: :airplane_arriving: :seat: :helicopter: :suspension_railway: :mountain_cableway: :aerial_tramway: :rocket: :satellite_orbital: :stars: :rainbow: :fireworks: :sparkler: :rice_scene: :checkered_flag:".split( " " )
			},
			symbols: {
				header: ":hash:",
				content: ":100: :1234: :eye_in_speech_bubble: :cupid: :heart: :heartbeat: :broken_heart: :two_hearts: :sparkling_heart: :heartpulse: :blue_heart: :green_heart: :yellow_heart: :purple_heart: :black_heart: :gift_heart: :revolving_hearts: :heart_decoration: :heart_exclamation: :anger: :boom: :dizzy: :speech_balloon: :speech_left: :anger_right: :thought_balloon: :white_flower: :globe_with_meridians: :hotsprings: :octagonal_sign: :clock12: :clock1230: :clock1: :clock130: :clock2: :clock230: :clock3: :clock330: :clock4: :clock430: :clock5: :clock530: :clock6: :clock630: :clock7: :clock730: :clock8: :clock830: :clock9: :clock930: :clock10: :clock1030: :clock11: :clock1130: :cyclone: :spades: :hearts: :diamonds: :clubs: :black_joker: :mahjong: :flower_playing_cards: :mute: :speaker: :sound: :loud_sound: :loudspeaker: :mega: :bell: :no_bell: :musical_note: :notes: :chart: :currency_exchange: :heavy_dollar_sign: :atm: :put_litter_in_its_place: :potable_water: :wheelchair: :mens: :womens: :restroom: :baby_symbol: :wc: :passport_control: :customs: :baggage_claim: :left_luggage: :warning: :children_crossing: :no_entry: :no_entry_sign: :no_bicycles: :no_smoking: :do_not_litter: :non-potable_water: :no_pedestrians: :no_mobile_phones: :underage: :radioactive: :biohazard: :arrow_up: :arrow_upper_right: :arrow_right: :arrow_lower_right: :arrow_down: :arrow_lower_left: :arrow_left: :arrow_upper_left: :arrow_up_down: :left_right_arrow: :leftwards_arrow_with_hook: :arrow_right_hook: :arrow_heading_up: :arrow_heading_down: :arrows_clockwise: :arrows_counterclockwise: :back: :end: :on: :soon: :top: :place_of_worship: :atom: :om_symbol: :star_of_david: :wheel_of_dharma: :yin_yang: :cross: :orthodox_cross: :star_and_crescent: :peace: :menorah: :six_pointed_star: :aries: :taurus: :gemini: :cancer: :leo: :virgo: :libra: :scorpius: :sagittarius: :capricorn: :aquarius: :pisces: :ophiuchus: :twisted_rightwards_arrows: :repeat: :repeat_one: :arrow_forward: :fast_forward: :track_next: :play_pause: :arrow_backward: :rewind: :track_previous: :arrow_up_small: :arrow_double_up: :arrow_down_small: :arrow_double_down: :pause_button: :stop_button: :record_button: :eject: :cinema: :low_brightness: :high_brightness: :signal_strength: :vibration_mode: :mobile_phone_off: :recycle: :name_badge: :fleur-de-lis: :beginner: :trident: :o: :white_check_mark: :ballot_box_with_check: :heavy_check_mark: :heavy_multiplication_x: :x: :negative_squared_cross_mark: :heavy_plus_sign: :heavy_minus_sign: :heavy_division_sign: :curly_loop: :loop: :part_alternation_mark: :eight_spoked_asterisk: :eight_pointed_black_star: :sparkle: :bangbang: :interrobang: :question: :grey_question: :grey_exclamation: :exclamation: :wavy_dash: :copyright: :registered: :tm: :hash: :asterisk: :zero: :one: :two: :three: :four: :five: :six: :seven: :eight: :nine: :keycap_ten: :capital_abcd: :abcd: :symbols: :abc: :a: :ab: :b: :cl: :cool: :free: :information_source: :id: :m: :new: :ng: :o2: :ok: :parking: :sos: :up: :vs: :koko: :sa: :u6708: :u6709: :u6307: :ideograph_advantage: :u5272: :u7121: :u7981: :accept: :u7533: :u5408: :u7a7a: :congratulations: :secret: :u55b6: :u6e80: :black_small_square: :white_small_square: :white_medium_square: :black_medium_square: :white_medium_small_square: :black_medium_small_square: :black_large_square: :white_large_square: :large_orange_diamond: :large_blue_diamond: :small_orange_diamond: :small_blue_diamond: :small_red_triangle: :small_red_triangle_down: :diamond_shape_with_a_dot_inside: :radio_button: :black_square_button: :white_square_button: :white_circle: :black_circle: :red_circle: :blue_circle: :regional_indicator_z: :regional_indicator_y: :regional_indicator_x: :regional_indicator_w: :regional_indicator_v: :regional_indicator_u: :regional_indicator_t: :regional_indicator_s: :regional_indicator_r: :regional_indicator_q: :regional_indicator_p: :regional_indicator_o: :regional_indicator_n: :regional_indicator_m: :regional_indicator_l: :regional_indicator_k: :regional_indicator_j: :regional_indicator_i: :regional_indicator_h: :regional_indicator_g: :regional_indicator_f: :regional_indicator_e: :regional_indicator_d: :regional_indicator_c: :regional_indicator_b: :regional_indicator_a:".split( " " )
			},
			flags: {
				header: ":flag_black:",
				content: ":flag_ac: :flag_ad: :flag_ae: :flag_af: :flag_ag: :flag_ai: :flag_al: :flag_am: :flag_ao: :flag_aq: :flag_ar: :flag_as: :flag_at: :flag_au: :flag_aw: :flag_ax: :flag_az: :flag_ba: :flag_bb: :flag_bd: :flag_be: :flag_bf: :flag_bg: :flag_bh: :flag_bi: :flag_bj: :flag_bl: :flag_bm: :flag_bn: :flag_bo: :flag_bq: :flag_br: :flag_bs: :flag_bt: :flag_bv: :flag_bw: :flag_by: :flag_bz: :flag_ca: :flag_cc: :flag_cd: :flag_cf: :flag_cg: :flag_ch: :flag_ci: :flag_ck: :flag_cl: :flag_cm: :flag_cn: :flag_co: :flag_cp: :flag_cr: :flag_cu: :flag_cv: :flag_cw: :flag_cx: :flag_cy: :flag_cz: :flag_de: :flag_dg: :flag_dj: :flag_dk: :flag_dm: :flag_do: :flag_dz: :flag_ea: :flag_ec: :flag_ee: :flag_eg: :flag_eh: :flag_er: :flag_es: :flag_et: :flag_eu: :flag_fi: :flag_fj: :flag_fk: :flag_fm: :flag_fo: :flag_fr: :flag_ga: :flag_gb: :flag_gd: :flag_ge: :flag_gf: :flag_gg: :flag_gh: :flag_gi: :flag_gl: :flag_gm: :flag_gn: :flag_gp: :flag_gq: :flag_gr: :flag_gs: :flag_gt: :flag_gu: :flag_gw: :flag_gy: :flag_hk: :flag_hm: :flag_hn: :flag_hr: :flag_ht: :flag_hu: :flag_ic: :flag_id: :flag_ie: :flag_il: :flag_im: :flag_in: :flag_io: :flag_iq: :flag_ir: :flag_is: :flag_it: :flag_je: :flag_jm: :flag_jo: :flag_jp: :flag_ke: :flag_kg: :flag_kh: :flag_ki: :flag_km: :flag_kn: :flag_kp: :flag_kr: :flag_kw: :flag_ky: :flag_kz: :flag_la: :flag_lb: :flag_lc: :flag_li: :flag_lk: :flag_lr: :flag_ls: :flag_lt: :flag_lu: :flag_lv: :flag_ly: :flag_ma: :flag_mc: :flag_md: :flag_me: :flag_mf: :flag_mg: :flag_mh: :flag_mk: :flag_ml: :flag_mm: :flag_mn: :flag_mo: :flag_mp: :flag_mq: :flag_mr: :flag_ms: :flag_mt: :flag_mu: :flag_mv: :flag_mw: :flag_mx: :flag_my: :flag_mz: :flag_na: :flag_nc: :flag_ne: :flag_nf: :flag_ng: :flag_ni: :flag_nl: :flag_no: :flag_np: :flag_nr: :flag_nu: :flag_nz: :flag_om: :flag_pa: :flag_pe: :flag_pf: :flag_pg: :flag_ph: :flag_pk: :flag_pl: :flag_pm: :flag_pn: :flag_pr: :flag_ps: :flag_pt: :flag_pw: :flag_py: :flag_qa: :flag_re: :flag_ro: :flag_rs: :flag_ru: :flag_rw: :flag_sa: :flag_sb: :flag_sc: :flag_sd: :flag_se: :flag_sg: :flag_sh: :flag_si: :flag_sj: :flag_sk: :flag_sl: :flag_sm: :flag_sn: :flag_so: :flag_sr: :flag_ss: :flag_st: :flag_sv: :flag_sx: :flag_sy: :flag_sz: :flag_ta: :flag_tc: :flag_td: :flag_tf: :flag_tg: :flag_th: :flag_tj: :flag_tk: :flag_tl: :flag_tm: :flag_tn: :flag_to: :flag_tr: :flag_tt: :flag_tv: :flag_tw: :flag_tz: :flag_ua: :flag_ug: :flag_um: :flag_us: :flag_uy: :flag_uz: :flag_va: :flag_vc: :flag_ve: :flag_vg: :flag_vi: :flag_vn: :flag_vu: :flag_wf: :flag_ws: :flag_xk: :flag_ye: :flag_yt: :flag_za: :flag_zm: :flag_zw:".split( " " )
			}*/
		};

		// CREATE EMOJI CONTAINER AND LOAD SECTION HEADER
		var createContainer = function( el )
		{
			$( '<div class="' + emojiContainer + '"><nav></nav></div>' ).insertAfter( el );

			var navItems = '';
			$.each( emojiList,
				function( k, v )
				{
					var emoji = emojione.shortnameToImage( v["header"] );
					navItems += '<div class="tab' + ( navItems == "" ? ' active' : '' ) + '" data-tab="' + k + '" onclick="">' + emoji + '</div>';
				}
			);

			$( "."  + emojiContainer +  " nav" ).append( navItems );

			$( "."  + emojiContainer +  " nav .tab" ).click(
				function()
				{
					loadEmojies( $( this ).attr( "data-tab" ) );
				}
			);

			// EMOJI CLICK EVENT
			$( document ).off( "click", "."  + emojiContainer +  " section .emojione" );
			$( document ).on( "click", "."  + emojiContainer +  " section .emojione",
				function()
				{
					var caretPos = activeEl.selectionStart;
					var textAreaTxt = $( activeEl ).val();
					var txtToAdd;
					if( settings.type=="shortcode" )
					{
						txtToAdd = $( this ).attr( "title" ) + " ";
					}else{
						txtToAdd = $( this ).attr( "alt" ) + " ";
					}

					$( activeEl ).val( textAreaTxt.substring( 0, caretPos ) + txtToAdd + textAreaTxt.substring( caretPos ) );
					$( activeEl ).focus();
					activeEl.selectionStart = caretPos + txtToAdd.length;
					activeEl.selectionEnd = caretPos + txtToAdd.length;
				}
			);
		};

		// GENERATE / CHANGE EMOJI SECTION
		var loadEmojies = function( section )
		{
			if( $( "."  + emojiContainer +  " section." + section ).length>0 )
			{
				if( $( "."  + emojiContainer +  " .tab[data-tab='" + section + "']" ).hasClass( "active" ) )
				{
					return;
				}

				$( "."  + emojiContainer +  " section" ).fadeOut().promise().done(
					function()
					{
						$( this ).hide();
						$( "."  + emojiContainer +  " section." + section ).fadeIn();
						$( "."  + emojiContainer +  " .tab" ).removeClass( "active");
						$( "."  + emojiContainer +  " .tab[data-tab='" + section + "']" ).addClass( "active");
					}
				);

				return;
			}

			if( typeof( emojiList[ section ] )=="undefined" )
			{
				return;
			}

			var sectionHtml = '';
			$.each( emojiList[ section ].content,
				function( k, v )
				{
					sectionHtml += emojione.shortnameToImage( v );
				}
			);

			$( '<section class="' + section + '">' + sectionHtml + '</section>' ).insertAfter( "."  + emojiContainer +  " nav" );

			$( "."  + emojiContainer +  " section" ).fadeOut().promise().done(
				function()
				{
					$( "."  + emojiContainer +  " section." + section ).fadeIn();
					$( "."  + emojiContainer +  " .tab" ).removeClass( "active");
					$( "."  + emojiContainer +  " .tab[data-tab='" + section + "']" ).addClass( "active");
				}
			);
		};

		// LOAD EMOJIONE
		var init = ( function()
		{
			var script = document.createElement("script"),
				head = document.querySelector("head"),
				style = document.createElement('link');

			script.src = 'https://cdn.jsdelivr.net/emojione/2.2.7/lib/js/emojione.min.js';
			style.type = "text/css";
			style.href = "https://cdn.jsdelivr.net/emojione/2.2.7/assets/css/emojione.min.css";

			head.appendChild( style );
			head.appendChild( script );

			script.onload = function()
			{
				createContainer( $el[0] );

				$.each( $el, function( i, el ){
					var picker = $( '<div class="emojionepicker-picker" data-index="' + i + '"></div>' ).insertAfter( el );

					// SET ACTIVE TEXTAREA
					picker.bind( "click", function(){
						activeEl = el;
					});

					var elOffset = $( el ).offset();

					picker.css({
						"top"  : elOffset["top"] + settings.pickerTop + "px",
						"left" : $( el ).width() + elOffset["left"] - $( ".emojionepicker-picker" ).width() - settings.pickerRight + "px",
					}).show();
				});

				// EMOJI PICKER CLICK EVENT
				$( ".emojionepicker-picker" ).click(
					function()
					{
						if( $( "."  + emojiContainer ).is( ":visible" ) )
						{
							$( "."  + emojiContainer ).fadeOut();
							return;
						}

						// LOAD SECTION EMOJIES
						loadEmojies( $( "."  + emojiContainer +  " nav div.active" ).attr( "data-tab" ) );

						var containerH = $( "."  + emojiContainer ).height();
						var containerW = $( "."  + emojiContainer ).width();
						var pickerOffset = $( this ).offset();

						var top, left;
						if( pickerOffset["top"] > ( containerH  - 15 )  )
						{
							top = pickerOffset["top"] - containerH - 15;
						}else{
							top = pickerOffset["top"] + $( this ).height() + 15;
						}

						if( pickerOffset["left"] > containerW )
						{
							left = pickerOffset["left"] - containerW + $( this ).width();
						}else{
							left = pickerOffset["left"];
						}

						$( "."  + emojiContainer ).css({
							"top"	: top + "px",
							"left"	: left + "px",
						}).fadeIn();
					}
				);

				// HIDE EMOJI CONTAINER ON CLICK ANYWHERE OUTSIDE THE ELEMENT
				$( document ).on( "click",
					function( e )
					{
						if( $( "."  + emojiContainer ).is( ":visible")==false || $( e.target ).is( ".emojionepicker-picker, .emojione" ) )
						{
							return;
						}

						$( "."  + emojiContainer ).fadeOut();
					}
				);
			}
		})();

		return this;
    };
}( jQuery ));