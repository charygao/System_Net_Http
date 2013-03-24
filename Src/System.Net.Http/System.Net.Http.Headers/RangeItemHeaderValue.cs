//
// RangeItemHeaderValue.cs
//
// Authors:
//	Marek Safar  <marek.safar@gmail.com>
//
// Copyright (C) 2011 Xamarin Inc (http://www.xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

namespace System.Net.Http.Headers {
	public class RangeItemHeaderValue : ICloneable {
		public RangeItemHeaderValue(long? from, long? to) {
			if (from == null && to == null) {
				throw new ArgumentException();
			}

			if (from != null && to != null && from > to) {
				throw new ArgumentOutOfRangeException("from");
			}

			if (from < 0) {
				throw new ArgumentOutOfRangeException("from");
			}

			if (to < 0) {
				throw new ArgumentOutOfRangeException("to");
			}

			this.From = from;
			this.To = to;
		}

		public long? From { get; private set; }
		public long? To { get; private set; }

		object ICloneable.Clone() {
			return this.MemberwiseClone();
		}

		public override bool Equals(object obj) {
			var source = obj as RangeItemHeaderValue;
			return source != null && source.From == this.From && source.To == this.To;
		}

		public override int GetHashCode() {
			return this.From.GetHashCode() ^ this.To.GetHashCode();
		}

		public override string ToString() {
			if (this.From == null) {
				return "-" + this.To.Value;
			}

			if (this.To == null) {
				return this.From.Value + "-";
			}

			return this.From.Value + "-" + this.To.Value;
		}
	}
}
