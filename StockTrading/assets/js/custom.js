$(document).ready(function() {
  $('.navbar-toggler').on('click', function () {
    $('.left-section').addClass('active')
  });
  $('.nav-close').on('click', function () {
    $('.left-section').removeClass('active')
  });
});
