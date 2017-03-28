namespace ApiPW{
	public interface ApiSubject
	{
		void Attach(ApiObserver observer);
		void Detach(ApiObserver observer);
		void Notify();
	}
}
