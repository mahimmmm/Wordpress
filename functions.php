<?php
function midnightzone_setup() {
    load_theme_textdomain( 'midnightzone', get_template_directory() . '/languages' );
	add_theme_support( 'automatic-feed-links' );
	add_theme_support( 'title-tag' );
	add_theme_support( 'post-thumbnails' );

	register_nav_menus(
		array(
			'menu-1' => esc_html__( 'Primary', 'midnightzone' ),
		)
	);

	add_theme_support(
		'html5',
		array(
			'search-form',
			'comment-form',
			'comment-list',
			'gallery',
			'caption',
			'style',
			'script',
		)
	);

	add_theme_support( 'customize-selective-refresh-widgets' );

	add_theme_support(
		'custom-logo',
		array(
			'height'      => 250,
			'width'       => 250,
			'flex-width'  => true,
			'flex-height' => true,
		)
	);
}
add_action( 'after_setup_theme', 'midnightzone_setup' );

function midnightzone_widgets_init() {
	register_sidebar(
		array(
			'name'          => esc_html__( 'Sidebar', 'midnightzone' ),
			'id'            => 'sidebar-1',
			'description'   => esc_html__( 'Add widgets here.', 'midnightzone' ),
			'before_widget' => '<section id="%1$s" class="widget %2$s">',
			'after_widget'  => '</section>',
			'before_title'  => '<h2 class="widget-title">',
			'after_title'   => '</h2>',
		)
	);

    // Header Ad Widget Area
    register_sidebar( array(
        'name'          => esc_html__( 'Header Ad', 'midnightzone' ),
        'id'            => 'header-ad',
        'description'   => esc_html__( 'Add your header ad widget here.', 'midnightzone' ),
        'before_widget' => '<div id="%1$s" class="widget %2$s">',
        'after_widget'  => '</div>',
        'before_title'  => '<h2 class="widget-title screen-reader-text">',
        'after_title'   => '</h2>',
    ) );

    // After Hero Ad Widget Area
    register_sidebar( array(
        'name'          => esc_html__( 'After Hero Ad', 'midnightzone' ),
        'id'            => 'after-hero-ad',
        'description'   => esc_html__( 'Add your after hero ad widget here.', 'midnightzone' ),
        'before_widget' => '<div id="%1$s" class="widget %2$s">',
        'after_widget'  => '</div>',
        'before_title'  => '<h2 class="widget-title screen-reader-text">',
        'after_title'   => '</h2>',
    ) );

    // Sidebar Ad Widget Area
    register_sidebar( array(
        'name'          => esc_html__( 'Sidebar Ad', 'midnightzone' ),
        'id'            => 'sidebar-ad',
        'description'   => esc_html__( 'Add your sidebar ad widget here.', 'midnightzone' ),
        'before_widget' => '<div id="%1$s" class="widget %2$s">',
        'after_widget'  => '</div>',
        'before_title'  => '<h2 class="widget-title">',
        'after_title'   => '</h2>',
    ) );
}
add_action( 'widgets_init', 'midnightzone_widgets_init' );

function midnightzone_scripts() {
	wp_enqueue_style( 'midnightzone-style', get_stylesheet_uri(), array(), wp_get_theme()->get( 'Version' ) );
	wp_style_add_data( 'midnightzone-style', 'rtl', 'replace' );

	if ( is_singular() && comments_open() && get_option( 'thread_comments' ) ) {
		wp_enqueue_script( 'comment-reply' );
	}
}
add_action( 'wp_enqueue_scripts', 'midnightzone_scripts' );
