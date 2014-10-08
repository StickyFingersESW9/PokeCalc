using UnityEngine;
using System.Collections;


public class PokeStatus : MonoBehaviour {


	public class StatusBase {

		private StatusBase() {

		}
		public StatusBase( int hp, int a, int b, int c, int d, int s ) {

			hp_ = hp;
			a_ = a;
			b_ = b;
			c_ = c;
			d_ = d;
			s_ = s;
		}

		public static StatusBase operator +( StatusBase lhs, StatusBase rhs ) {

			StatusBase result = new StatusBase( 0, 0, 0, 0, 0, 0 );

			result.hp_ = lhs.hp_ + rhs.hp_;
			result.a_ = lhs.a_ + rhs.a_;
			result.b_ = lhs.b_ + rhs.b_;
			result.c_ = lhs.c_ + rhs.c_;
			result.d_ = lhs.d_ + rhs.d_;
			result.s_ = lhs.s_ + rhs.s_;

			return result;
		}

		public static StatusBase operator -( StatusBase lhs, StatusBase rhs ) {

			StatusBase result = new StatusBase( 0, 0, 0, 0, 0, 0 );

			result.hp_ = lhs.hp_ - rhs.hp_;
			result.a_ = lhs.a_ - rhs.a_;
			result.b_ = lhs.b_ - rhs.b_;
			result.c_ = lhs.c_ - rhs.c_;
			result.d_ = lhs.d_ - rhs.d_;
			result.s_ = lhs.s_ - rhs.s_;

			return result;
		}

		public static StatusBase operator *( StatusBase lhs, int rhs ) {

			StatusBase result = new StatusBase( 0, 0, 0, 0, 0, 0 );

			result.hp_ = lhs.hp_ * rhs;
			result.a_ = lhs.a_ * rhs;
			result.b_ = lhs.b_ * rhs;
			result.c_ = lhs.c_ * rhs;
			result.d_ = lhs.d_ * rhs;
			result.s_ = lhs.s_ * rhs;

			return result;
		}

		public static StatusBase operator *( StatusBase lhs, Entity_pokemon_personality.Param rhs ) {

			StatusBase result = new StatusBase( 0, 0, 0, 0, 0, 0 );

			result.hp_ = lhs.hp_;
			result.a_ = (int)(lhs.a_ * rhs.A);
			result.b_ = (int)(lhs.b_ * rhs.B);
			result.c_ = (int)(lhs.c_ * rhs.C);
			result.d_ = (int)(lhs.d_ * rhs.D);
			result.s_ = (int)(lhs.s_ * rhs.S);

			return result;
		}

		public static StatusBase operator /( StatusBase lhs, int rhs ) {

			StatusBase result = new StatusBase( 0, 0, 0, 0, 0, 0 );

			result.hp_ = lhs.hp_ / rhs;
			result.a_ = lhs.a_ / rhs;
			result.b_ = lhs.b_ / rhs;
			result.c_ = lhs.c_ / rhs;
			result.d_ = lhs.d_ / rhs;
			result.s_ = lhs.s_ / rhs;

			return result;
		}

		protected int hp_;
		public int HP {
			set { hp_ = value; }
			get { return hp_; }
		}
		protected int a_;
		public int A {
			set { a_ = value; }
			get { return a_; }
		}
		protected int b_;
		public int B {
			set { b_ = value; }
			get { return b_; }
		}
		protected int c_;
		public int C {
			set { c_ = value; }
			get { return c_; }
		}
		protected int d_;
		public int D {
			set { d_ = value; }
			get { return d_; }
		}
		protected int s_;
		public int S {
			set { s_ = value; }
			get { return s_; }
		}

	}


	/**
	 * @brief 種族値クラス.
	 */
	public class PokeTribal : StatusBase {

		private PokeTribal() : base( 0, 0, 0, 0, 0, 0 ) {
		}
		public PokeTribal( int hp, int a, int b, int c, int d, int s ) : base( hp, a, b, c, d, s ) {
		}
		public PokeTribal( Entity_pokemon_db.Param db ) : base( 0, 0, 0, 0, 0, 0 ) {

			Import( db );
		}

		public void Import( Entity_pokemon_db.Param db ) {

			hp_ = db.HP;
			a_ = db.A;
			b_ = db.B;
			c_ = db.C;
			d_ = db.D;
			s_ = db.S;
		}
	}

	/**
	 * @brief 個体値クラス.
	 */
	public class PokeIndividual : StatusBase {

		private PokeIndividual() : base( 0, 0, 0, 0, 0, 0 ) {
		}
		public PokeIndividual( int hp, int a, int b, int c, int d, int s ) : base( hp, a, b, c, d, s ) {
		}

	}

	/**
	 * @brief 努力値クラス.
	 */
	public class PokeEffort : StatusBase {

		private PokeEffort() : base( 0, 0, 0, 0, 0, 0 ) {
		}
		public PokeEffort( int hp, int a, int b, int c, int d, int s ) : base( hp, a, b, c, d, s ) {
		}

	}


}


