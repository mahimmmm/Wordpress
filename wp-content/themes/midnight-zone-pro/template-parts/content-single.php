<?php
/**
 * Template part for displaying single posts
 *
 * @package Midnight_Zone_Pro
 */
?>
<article id="post-<?php the_ID(); ?>" <?php post_class(); ?>>
	<?php if ( has_post_thumbnail() ) : ?>
		<div class="post-thumbnail-full">
			<?php the_post_thumbnail( 'full' ); ?>
		</div>
	<?php endif; ?>
	<header class="entry-header">
		<?php the_title( '<h1 class="entry-title">', '</h1>' ); ?>
		<div class="entry-meta">
			<span class="posted-on"><?php the_date(); ?></span>
			<span class="byline"> <?php esc_html_e( 'by', 'midnight-zone-pro' ); ?> <?php the_author_posts_link(); ?></span>
			<span class="cat-links"> <?php esc_html_e( 'in', 'midnight-zone-pro' ); ?> <?php the_category( ', ' ); ?></span>
		</div>
	</header>
	<div class="entry-content">
		<?php
		the_content();

		// In-article ad placement logic could be more sophisticated
		if ( is_active_sidebar( 'in_article_ad' ) ) {
			echo '<div class="in-article-ad ad-area">';
			dynamic_sidebar( 'in_article_ad' );
			echo '</div>';
		}

		wp_link_pages();
		?>
	</div>
	<footer class="entry-footer">
		<?php the_tags( '<span class="tags-links">', '', '</span>' ); ?>
	</footer>
</article>
