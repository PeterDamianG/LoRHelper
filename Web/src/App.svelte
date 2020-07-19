<script>
	import CustomHead from './CustomHead.svelte';
	import SectionFirst from './SectionFirst.svelte';
	import SectionSummary from './SectionSummary.svelte';
	import SectionVideo from './SectionVideo.svelte';
	import Footer from './Footer.svelte';
</script>

<CustomHead/>
<SectionFirst/>
<SectionSummary/>
<SectionVideo/>
<Footer/>

<style>
	:global(*) {
		box-sizing: border-box;
	}
	:global(body) {
		text-rendering: optimizeLegibility;
		display: flex;
		flex-direction: column;
		margin: 0;
		padding: 0;
	}
	:global(html) {
		line-height: 1.15;
		-webkit-text-size-adjust: 100%;
	}
</style>