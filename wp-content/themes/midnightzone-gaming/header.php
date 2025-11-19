<!doctype html>
<html <?php language_attributes(); ?>>
<head>
	<meta charset="<?php bloginfo( 'charset' ); ?>">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="profile" href="https://gmpg.org/xfn/11">
	<?php wp_head(); ?>
</head>

<body <?php body_class(); ?>>
<?php wp_body_open(); ?>
<div id="page" class="site">
	<a class="skip-link screen-reader-text" href="#primary"><?php esc_html_e( 'Skip to content', 'midnightzone-gaming' ); ?></a>

	<header id="masthead" class="site-header">
		<div class="container header-container">
			<div class="site-branding">
                <h1 class="site-title"><a href="<?php echo esc_url( home_url( '/' ) ); ?>" rel="home">MidnightZone</a></h1>
			</div><!-- .site-branding -->

            <button class="menu-toggle" aria-controls="primary-menu" aria-expanded="false"><?php esc_html_e( 'Menu', 'midnightzone-gaming' ); ?></button>
			<nav id="site-navigation" class="main-navigation">
				<?php
				wp_nav_menu(
					array(
						'theme_location' => 'primary',
						'menu_id'        => 'primary-menu',
					)
				);
				?>
			</nav><!-- #site-navigation -->

            <div class="header-right">
                <?php get_search_form(); ?>
                <div class="login-link">
                    <?php wp_loginout( home_url() ); ?>
                </div>
                <button id="dark-mode-toggle" aria-label="Toggle Dark Mode">🌙</button>
            </div>
		</div><!-- .container -->
	</header><!-- #masthead -->

    <?php if ( is_active_sidebar( 'ad-header' ) ) : ?>
        <div class="header-ad-area">
            <?php dynamic_sidebar( 'ad-header' ); ?>
        </div>
    <?php endif; ?>

	<div id="content" class="site-content container">
        <div id="primary" class="content-area">
            <main id="main" class="site-main">
