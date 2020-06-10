$(function () {
	$('a[href="#search"]').on('click', function (event) {
		event.preventDefault();
		$('#search').addClass('open');
		$('#search > form > input[type="search"]').focus();
	});
	$('#search').on('click keyup', function (event) {
		if (event.target == this || event.target.className == 'close' || event.keyCode == 27) {
			$(this).removeClass('open');
		}
	});
});

var keys = { 37: 1, 38: 1, 39: 1, 40: 1 };

function preventDefault(e) {
    e.preventDefault();
}

function preventDefaultForScrollKeys(e) {
    if (keys[e.keyCode]) {
        preventDefault(e);
        return false;
    }
}

// modern Chrome requires { passive: false } when adding event
var supportsPassive = false;
try {
    window.addEventListener("test", null, Object.defineProperty({}, 'passive', {
        get: function () { supportsPassive = true; }
    }));
} catch (e) { }

var wheelOpt = supportsPassive ? { passive: false } : false;
var wheelEvent = 'onwheel' in document.createElement('div') ? 'wheel' : 'mousewheel';

// call this to Disable
function disableScroll() {
    window.addEventListener('DOMMouseScroll', preventDefault, false); // older FF
    window.addEventListener(wheelEvent, preventDefault, wheelOpt); // modern desktop
    window.addEventListener('touchmove', preventDefault, wheelOpt); // mobile
    window.addEventListener('keydown', preventDefaultForScrollKeys, false);
}

// call this to Enable
function enableScroll() {
    window.removeEventListener('DOMMouseScroll', preventDefault, false);
    window.removeEventListener(wheelEvent, preventDefault, wheelOpt);
    window.removeEventListener('touchmove', preventDefault, wheelOpt);
    window.removeEventListener('keydown', preventDefaultForScrollKeys, false);
}

//let bar = document.getElementById('bar');
//let barMenu = document.getElementById('bar-menu');
//let closeBar = document.getElementById('bar-close');
//let barBodyGray = document.getElementById('bar-body-gray');
//bar.addEventListener('click', checkBarMenu);
//closeBar.addEventListener('click', checkBarMenu);
//function checkBarMenu() {
//    let check = barMenu.getAttribute('class');
//    if (check.includes('d-none') || check.includes('bar-not-d-none')) {
//        barMenu.classList.remove('bar-not-d-none');
//        barMenu.classList.remove('d-none');
//        closeBar.classList.remove('d-none');
//        barBodyGray.classList.remove('d-none');

//        window.addEventListener('keydown', preventDefaultForScrollKeys, false);
//    }
//    else {
//        barMenu.classList.add('bar-not-d-none');
//        closeBar.classList.add('d-none');
//        barBodyGray.classList.add('d-none');

//        window.removeEventListener('keydown', preventDefaultForScrollKeys, false);
//    }
//}