const mix = require('laravel-mix');

mix.sass('assets/scss/app.scss', 'wwwroot/css');
mix.js('assets/js/app.js', 'wwwroot/js');