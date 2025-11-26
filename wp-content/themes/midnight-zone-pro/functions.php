<?php
/**
 * Midnight Zone Pro functions and definitions
 *
 * @link https://developer.wordpress.org/themes/basics/theme-functions/
 *
 * @package Midnight_Zone_Pro
 */

if ( ! function_exists( 'midnight_zone_pro_setup' ) ) :
	/**
	 * Sets up theme defaults and registers support for various WordPress features.
	 */
	function midnight_zone_pro_setup() {
		// Make theme available for translation.
		load_theme_textdomain( 'midnight-zone-pro', get_template_directory() . '/languages' );

		// Add default posts and comments RSS feed links to head.
		add_theme_support( 'automatic-feed-links' );

		// Let WordPress manage the document title.
		add_theme_support( 'title-tag' );

		// Enable support for Post Thumbnails on posts and pages.
		add_theme_support( 'post-thumbnails' );

		// This theme uses wp_nav_menu() in one location.
		register_nav_menus(
			array(
				'primary' => esc_html__( 'Primary Menu', 'midnight-zone-pro' ),
			)
		);

		// Switch default core markup for search form, comment form, and comments to output valid HTML5.
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
	}
endif;
add_action( 'after_setup_theme', 'midnight_zone_pro_setup' );

/**
 * Register widget area.
 */
function midnight_zone_pro_widgets_init() {
	register_sidebar( array(
		'name'          => esc_html__( 'Sidebar', 'midnight-zone-pro' ),
		'id'            => 'sidebar-1',
		'before_widget' => '<section id="%1$s" class="widget %2$s">',
		'after_widget'  => '</section>',
		'before_title'  => '<h2 class="widget-title">',
		'after_title'   => '</h2>',
	) );

	// Ad Widget Areas
	$ad_spots = [
		'header_ad'           => __( 'Header Ad (728x90 or 970x90)', 'midnight-zone-pro' ),
		'after_hero_ad'       => __( 'After Hero Ad (728x90 or 970x250)', 'midnight-zone-pro' ),
		'sidebar_large_ad'    => __( 'Sidebar Large Ad (300x600)', 'midnight-zone-pro' ),
		'sidebar_medium_ad'   => __( 'Sidebar Medium Ad (300x250)', 'midnight-zone-pro' ),
		'before_footer_ad'    => __( 'Before Footer Ad (728x90 or 970x250)', 'midnight-zone-pro' ),
		'in_article_ad'       => __( 'In-Article Ad (300x250)', 'midnight-zone-pro' ),
		'after_comments_ad'   => __( 'After Comments Ad (728x90)', 'midnight-zone-pro' ),
	];

	foreach ( $ad_spots as $id => $name ) {
		register_sidebar( array(
			'name'          => $name,
			'id'            => $id,
			'before_widget' => '<div id="%1$s" class="widget ad-widget %2$s">',
			'after_widget'  => '</div>',
			'before_title'  => '<h2 class="widget-title screen-reader-text">',
			'after_title'   => '</h2>',
		) );
	}

	// Footer Widget Areas
	for ( $i = 1; $i <= 4; $i++ ) {
		register_sidebar( array(
			'name'          => sprintf( esc_html__( 'Footer Column %d', 'midnight-zone-pro' ), $i ),
			'id'            => 'footer-' . $i,
			'before_widget' => '<section id="%1$s" class="widget %2$s">',
			'after_widget'  => '</section>',
			'before_title'  => '<h4 class="widget-title">',
			'after_title'   => '</h4>',
		) );
	}
}
add_action( 'widgets_init', 'midnight_zone_pro_widgets_init' );

/**
 * Enqueue scripts and styles.
 */
function midnight_zone_pro_scripts() {
	// Google Fonts
	wp_enqueue_style( 'midnight-zone-pro-fonts', 'https://fonts.googleapis.com/css2?family=Playfair+Display:wght@700&family=Inter:wght@400;500&display=swap', array(), null );

	// Font Awesome
	wp_enqueue_style( 'font-awesome', 'https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css', array(), '6.5.1' );

	// Theme stylesheet.
	wp_enqueue_style( 'midnight-zone-pro-style', get_stylesheet_uri(), array(), '1.0' );

	// Theme JS
    wp_enqueue_script( 'midnight-zone-pro-theme', get_template_directory_uri() . '/assets/js/theme.js', array(), '1.0', true );

	// Library scripts
	if ( is_front_page() ) {
		wp_enqueue_script( 'particles', get_template_directory_uri() . '/assets/js/particles.min.js', array(), '2.0.0', true );
		wp_enqueue_script( 'vanilla-tilt', get_template_directory_uri() . '/assets/js/vanilla-tilt.min.js', array(), '1.7.0', true );
		wp_enqueue_script( 'midnight-zone-pro-custom', get_template_directory_uri() . '/assets/js/custom.js', array( 'particles', 'vanilla-tilt' ), '1.0', true );
	}
}
add_action( 'wp_enqueue_scripts', 'midnight_zone_pro_scripts' );
