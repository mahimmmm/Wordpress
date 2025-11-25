<aside id="secondary" class="widget-area">
    <?php if ( is_active_sidebar( 'sidebar-ad' ) ) : ?>
        <div class="sidebar-ad">
            <?php dynamic_sidebar( 'sidebar-ad' ); ?>
        </div>
    <?php endif; ?>
	<?php dynamic_sidebar( 'sidebar-1' ); ?>
</aside><!-- #secondary -->
