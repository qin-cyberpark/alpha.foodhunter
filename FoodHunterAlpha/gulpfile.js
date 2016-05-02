/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify");


var contentPath = "./Content/";
var fileGroups = [{ src: "js/customer/**/*.js", exclude: "js/customer/**/*.min.js", dest: "dist/js/site-customer.min.js" },
                  { src: "css/customer/**/*.css", exclude: "css/customer/**/*.min.css", dest: "dist/css/site-customer.min.css" },
                  { src: "js/counter/**/*.js", exclude: "js/counter/**/*.min.js", dest: "dist/js/site-counter.min.js" },
                  { src: "css/counter/**/*.css", exclude: "css/counter/**/*.min.css", dest: "dist/css/site-counter.min.css" }];

gulp.task("clean", function (cb) {
    for (var i = 0; i < fileGroups.length; i++) {
        rimraf(contentPath + fileGroups[i].dest, cb);
    }
});


gulp.task("min", function () {
    for (var i = 0; i < fileGroups.length; i++) {
        gulp.src([contentPath + fileGroups[i].src, "!" + contentPath + fileGroups[i].exclude])
                .pipe(concat(contentPath + fileGroups[i].dest))
                .pipe(cssmin())
                .pipe(gulp.dest("."));
    }
});
