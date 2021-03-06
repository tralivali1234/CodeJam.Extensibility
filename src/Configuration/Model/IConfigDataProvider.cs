using System.Xml;

namespace CodeJam.Extensibility.Configuration
{
	/// <summary>
	/// ��������� ������ � ���������������� �����������.
	/// </summary>
	public interface IConfigDataProvider
	{
		/// <summary>
		/// ������ ������ ������������.
		/// </summary>
		/// <remarks>����� ����� ��������� ���������� �����</remarks>
		XmlReader ReadData();

		/// <summary>
		/// ��������� include.
		/// </summary>
		IConfigDataProvider ResolveInclude(string path);

		/// <summary>
		/// ���������� ��� ��������� ����� ������������ �������� ����������.
		/// </summary>
		event EventHandler<IConfigDataProvider> ConfigChanged;
	}
}