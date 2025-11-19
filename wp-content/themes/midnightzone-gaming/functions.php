<?php
/**
 * MidnightZone Gaming functions and definitions
 *
 * @link https://developer.wordpress.org/themes/basics/theme-functions/
 *
 * @package MidnightZone_Gaming
 */

if ( ! defined( 'MIDNIGHTZONE_GAMING_VERSION' ) ) {
	// Replace the version number of the theme on each release.
	define( 'MIDNIGHTZONE_GAMING_VERSION', '1.0.0' );
}

if ( ! function_exists( 'midnightzone_gaming_setup' ) ) :
	/**
	 * Sets up theme defaults and registers support for various WordPress features.
	 */
	function midnightzone_gaming_setup() {
		// Make theme available for translation.
		load_theme_textdomain( 'midnightzone-gaming', get_template_directory() . '/languages' );

		// Add default posts and comments RSS feed links to head.
		add_theme_support( 'automatic-feed-links' );

		// Let WordPress manage the document title.
		add_theme_support( 'title-tag' );

		// Enable support for Post Thumbnails on posts and pages.
		add_theme_support( 'post-thumbnails' );

		// Register navigation menus.
		register_nav_menus(
			array(
				'primary' => esc_html__( 'Primary Menu', 'midnightzone-gaming' ),
                'footer'  => esc_html__( 'Footer Quick Links', 'midnightzone-gaming' ),
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

        // Add theme support for selective refresh for widgets.
		add_theme_support( 'customize-selective-refresh-widgets' );

        // Add support for core block styles.
        add_theme_support( 'wp-block-styles' );

        // Add support for wide alignment.
        add_theme_support( 'align-wide' );
	}
endif;
add_action( 'after_setup_theme', 'midnightzone_gaming_setup' );

/**
 * Register widget areas.
 */
function midnightzone_gaming_widgets_init() {
	register_sidebar(
		array(
			'name'          => esc_html__( 'Main Sidebar', 'midnightzone-gaming' ),
			'id'            => 'sidebar-1',
			'description'   => esc_html__( 'Add widgets here.', 'midnightzone-gaming' ),
			'before_widget' => '<section id="%1$s" class="widget %2$s">',
			'after_widget'  => '</section>',
			'before_title'  => '<h2 class="widget-title">',
			'after_title'   => '</h2>',
		)
	);
    // Ad Widgets
    register_sidebar( array( 'name' => __( 'Ad: Header (728x90)', 'midnightzone-gaming' ), 'id' => 'ad-header', 'before_widget' => '<div class="ad-spot ad-spot-top">', 'after_widget' => '</div>' ) );
    register_sidebar( array( 'name' => __( 'Ad: Below Hero (336x280)', 'midnightzone-gaming' ), 'id' => 'ad-below-hero', 'before_widget' => '<div class="ad-spot ad-spot-middle">', 'after_widget' => '</div>' ) );
    register_sidebar( array( 'name' => __( 'Ad: Sidebar (300x600)', 'midnightzone-gaming' ), 'id' => 'ad-sidebar', 'before_widget' => '<div class="ad-spot ad-spot-sidebar">', 'after_widget' => '</div>' ) );
    register_sidebar( array( 'name' => __( 'Ad: Footer (728x90)', 'midnightzone-gaming' ), 'id' => 'ad-footer', 'before_widget' => '<div class="ad-spot ad-spot-footer">', 'after_widget' => '</div>' ) );

    // Footer Widgets
    register_sidebar( array( 'name' => __( 'Footer Column 1: Quick Links', 'midnightzone-gaming' ), 'id' => 'footer-1' ) );
    register_sidebar( array( 'name' => __( 'Footer Column 2: Social Icons', 'midnightzone-gaming' ), 'id' => 'footer-2' ) );
    register_sidebar( array( 'name' => __( 'Footer Column 3: Copyright', 'midnightzone-gaming' ), 'id' => 'footer-3' ) );
}
add_action( 'widgets_init', 'midnightzone_gaming_widgets_init' );

/**
 * Enqueue scripts and styles.
 */
function midnightzone_gaming_scripts() {
    // Google Fonts
    wp_enqueue_style( 'google-fonts', 'https://fonts.googleapis.com/css2?family=Orbitron:wght@700&family=Rajdhani:wght@400;700&display=swap', array(), null );

    // Theme stylesheet.
	wp_enqueue_style( 'midnightzone-gaming-style', get_stylesheet_uri(), array(), MIDNIGHTZONE_GAMING_VERSION );

    // Theme javascript.
	wp_enqueue_script( 'midnightzone-gaming-main-js', get_template_directory_uri() . '/assets/js/main.js', array('jquery'), MIDNIGHTZONE_GAMING_VERSION, true );

    // Localize script for AJAX
    wp_localize_script( 'midnightzone-gaming-main-js', 'mzg_ajax', array(
        'ajax_url' => admin_url( 'admin-ajax.php' ),
        'nonce'    => wp_create_nonce( 'mzg-load-more-nonce' )
    ));

	if ( is_singular() && comments_open() && get_option( 'thread_comments' ) ) {
		wp_enqueue_script( 'comment-reply' );
	}
}
add_action( 'wp_enqueue_scripts', 'midnightzone_gaming_scripts' );


/**
 * Breadcrumbs Function
 */
if ( ! function_exists( 'midnightzone_gaming_breadcrumbs' ) ) :
    function midnightzone_gaming_breadcrumbs() {
        if ( is_front_page() ) return;

        echo '<div class="breadcrumbs">';
        echo '<a href="' . esc_url( home_url() ) . '">Home</a> &raquo; ';

        if ( is_category() || is_single() ) {
            the_category( ' &raquo; ' );
            if ( is_single() ) {
                echo " &raquo; ";
                the_title();
            }
        } elseif ( is_page() ) {
            the_title();
        } elseif ( is_search() ) {
            echo 'Search results for "' . get_search_query() . '"';
        }

        echo '</div>';
    }
endif;

/**
 * Related Posts Function
 */
if ( ! function_exists( 'midnightzone_gaming_related_posts' ) ) :
    function midnightzone_gaming_related_posts() {
        global $post;
        $categories = get_the_category( $post->ID );
        if ( $categories ) {
            $category_ids = array();
            foreach( $categories as $individual_category ) $category_ids[] = $individual_category->term_id;

            $args = array(
                'category__in'        => $category_ids,
                'post__not_in'        => array( $post->ID ),
                'posts_per_page'      => 4,
                'ignore_sticky_posts' => 1
            );

            $query = new wp_query( $args );

            if( $query->have_posts() ) {
                echo '<section class="related-posts">';
                echo '<h3>Related Posts</h3>';
                echo '<div class="post-grid">';
                while( $query->have_posts() ) {
                    $query->the_post();
                    get_template_part( 'template-parts/content', 'grid' );
                }
                echo '</div>';
                echo '</section>';
            }
        }
        wp_reset_postdata();
    }
endif;

/**
 * AJAX Load More Posts
 */
function midnightzone_gaming_load_more_posts() {
    check_ajax_referer( 'mzg-load-more-nonce', 'nonce' );

    $paged = $_POST['page'] + 1;
    $query_vars = json_decode( stripslashes( $_POST['query_vars'] ), true );
    $query_vars['paged'] = $paged;

    $query = new WP_Query($query_vars);

    if ($query->have_posts()) {
        while ($query->have_posts()) {
            $query->the_post();
            get_template_part('template-parts/content', 'grid');
        }
    }

    wp_die();
}
add_action('wp_ajax_load_more_posts', 'midnightzone_gaming_load_more_posts');
add_action('wp_ajax_nopriv_load_more_posts', 'midnightzone_gaming_load_more_posts');

/**
 * Setup demo widgets on theme activation.
 */
function midnightzone_gaming_setup_demo_widgets( $old_theme_name ) {
    // Set up default text widgets with instructions for the ad spots
    $sidebars = get_option( 'sidebars_widgets' );
    $text_widgets = get_option( 'widget_text', array() );

    // Header Ad
    $text_widgets[1] = array( 'title' => 'Header Ad (728x90)', 'text' => '<!-- Paste your 728x90 ad code here -->' );
    $sidebars['ad-header'][0] = 'text-1';

    // Below Hero Ad
    $text_widgets[2] = array( 'title' => 'Below Hero Ad (336x280)', 'text' => '<!-- Paste your 336x280 ad code here -->' );
    $sidebars['ad-below-hero'][0] = 'text-2';

    // Sidebar Ad
    $text_widgets[3] = array( 'title' => 'Sidebar Ad (300x600)', 'text' => '<!-- Paste your 300x600 ad code here -->' );
    $sidebars['ad-sidebar'][0] = 'text-3';

    // Footer Ad
    $text_widgets[4] = array( 'title' => 'Footer Ad (728x90)', 'text' => '<!-- Paste your 728x90 ad code here -->' );
    $sidebars['ad-footer'][0] = 'text-4';

    // Add other default widgets to the main sidebar
    $sidebars['sidebar-1'] = array(
        'categories-2',
        'recent-posts-2',
        'recent-posts-3',
    );

    update_option( 'widget_categories', array( 2 => array( 'title' => 'Categories' ) ) );
    $recent_posts_widgets = get_option( 'widget_recent-posts', array() );
    $recent_posts_widgets[2] = array( 'title' => 'Trending Posts', 'number' => 5 );
    $recent_posts_widgets[3] = array( 'title' => 'Popular Posts', 'number' => 5 );
    update_option( 'widget_recent-posts', $recent_posts_widgets );

    update_option( 'widget_text', $text_widgets );
    update_option( 'sidebars_widgets', $sidebars );
}
add_action( 'after_switch_theme', 'midnightzone_gaming_setup_demo_widgets' );

/**
 * Add a pingback url auto-discovery header for single posts, pages, or attachments.
 */
function midnightzone_gaming_pingback_header() {
	if ( is_singular() && pings_open() ) {
		printf( '<link rel="pingback" href="%s">', esc_url( get_bloginfo( 'pingback_url' ) ) );
	}
}
add_action( 'wp_head', 'midnightzone_gaming_pingback_header' );

/**
 * Post Views Counter
 */
function mzg_get_post_views($postID){
    $count_key = 'mzg_post_views_count';
    $count = get_post_meta($postID, $count_key, true);
    if($count==''){
        delete_post_meta($postID, $count_key);
        add_post_meta($postID, $count_key, '0');
        return "0 View";
    }
    return $count.' Views';
}

function mzg_set_post_views($postID) {
    $count_key = 'mzg_post_views_count';
    $count = get_post_meta($postID, $count_key, true);
    if($count==''){
        $count = 0;
        delete_post_meta($postID, $count_key);
        add_post_meta($postID, $count_key, '0');
    }else{
        $count++;
        update_post_meta($postID, $count_key, $count);
    }
}
