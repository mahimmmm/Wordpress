<?php
/**
 * The header for our theme
 *
 * @package Midnight_Zone_Pro
 */
?>
<!doctype html>
<html <?php language_attributes(); ?>>
<head>
	<meta charset="<?php bloginfo( 'charset' ); ?>">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="profile" href="https://gmpg.org/xfn/11">
	<?php wp_head(); ?>
</head>
<body <?php body_class(); ?>>
<div id="page" class="site">
	<a class="skip-link screen-reader-text" href="#content"><?php esc_html_e( 'Skip to content', 'midnight-zone-pro' ); ?></a>
	<header id="masthead" class="site-header sticky-header">
		<div class="header-container">
			<div class="site-branding">
				<!-- Neon Glow Logo -->
				<a href="<?php echo esc_url( home_url( '/' ) ); ?>" rel="home" class="neon-logo">
					<?php bloginfo( 'name' ); ?>
				</a>
			</div>
			<nav id="site-navigation" class="main-navigation">
				<?php
				wp_nav_menu( array(
					'theme_location' => 'primary',
					'menu_id'        => 'primary-menu',
				) );
				?>
			</nav>
			<div class="header-right">
				<div class="search-icon">
					<i class="fas fa-search"></i>
				</div>
				<div class="mode-toggle">
					<i class="fas fa-sun"></i>
				</div>
				<div class="social-icons">
					<!-- Add social icons here -->
					<a href="#"><i class="fab fa-facebook-f"></i></a>
					<a href="#"><i class="fab fa-twitter"></i></a>
					<a href="#"><i class="fab fa-instagram"></i></a>
				</div>
			</div>
			<div class="mobile-menu-toggle">
				<i class="fas fa-bars"></i>
			</div>
		</div>
	</header><!-- #masthead -->
	<div id="content" class="site-content">
