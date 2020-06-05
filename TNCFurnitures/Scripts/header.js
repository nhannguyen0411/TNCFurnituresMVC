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

// FOR BAR MENU
let bar = document.getElementById('bar');
let barMenu = document.getElementById('bar-menu');
let closeBar = document.getElementById('bar-close');
let barBodyGray = document.getElementById('bar-body-gray');
bar.addEventListener('click', checkBarMenu);
closeBar.addEventListener('click', checkBarMenu);
function checkBarMenu() {
	let check = barMenu.getAttribute('class');
	if (check.includes('d-none') || check.includes('bar-not-d-none')) {
		barMenu.classList.remove('bar-not-d-none');
		barMenu.classList.remove('d-none');
		closeBar.classList.remove('d-none');
		barBodyGray.classList.remove('d-none');
	}
	else {
		barMenu.classList.add('bar-not-d-none');
		closeBar.classList.add('d-none');
		barBodyGray.classList.add('d-none');
	}
}