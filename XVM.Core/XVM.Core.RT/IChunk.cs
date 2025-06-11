namespace XVM.Core.RT
{
	public interface IChunk
	{
		uint Length { get; }

		void OnOffsetComputed(uint uint_0);

		byte[] GetData();
	}
}
