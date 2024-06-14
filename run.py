import os
from flask import Flask, request, render_template, redirect, url_for
import face_recognition
import cv2
from werkzeug.utils import secure_filename
import pyodbc
from flask_sqlalchemy import SQLAlchemy

app = Flask(__name__)

# Configuration for SQL Server connection
app.config['SQLALCHEMY_DATABASE_URI'] = 'mssql+pyodbc://@./project_v19?driver=ODBC+Driver+17+for+SQL+Server'
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False

# Initialize SQLAlchemy
db = SQLAlchemy(app)

class Person(db.Model):
    __tablename__ = 'Persons'
    NationalPerson_Id = db.Column(db.Integer, primary_key=True)
    Name = db.Column(db.String)
    HomePhoneNumber = db.Column(db.String)
    Gender = db.Column(db.String)
    Address = db.Column(db.String)
    DateOfBirth = db.Column(db.Date)
    Nots = db.Column(db.String)
    Is_he_missing = db.Column(db.Boolean)
    ImageName = db.Column(db.String)
    National_Father_Id_FK = db.Column(db.Integer)
    National_Mother_Id_FK = db.Column(db.Integer)

# Directory to save uploaded files
UPLOAD_FOLDER = os.path.join(app.root_path, 'uploads')
os.makedirs(UPLOAD_FOLDER, exist_ok=True)
app.config['UPLOAD_FOLDER'] = UPLOAD_FOLDER

def recognize_faces_in_image(image_path, known_encodings_folder):
    known_encodings = load_encodings_from_folder(known_encodings_folder)
    image = face_recognition.load_image_file(image_path)
    rgb_image = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
    face_locations = face_recognition.face_locations(rgb_image)
    face_encodings = face_recognition.face_encodings(rgb_image, face_locations)

    recognized_names = []

    for face_encoding in face_encodings:
        best_match_name, _ = find_nearest_match(face_encoding, known_encodings)
        recognized_names.append(best_match_name)

    return recognized_names

def load_encodings_from_folder(folder_path):
    encodings = {}
    for file_name in os.listdir(folder_path):
        if file_name.endswith(".txt"):
            file_path = os.path.join(folder_path, file_name)
            with open(file_path, 'r') as file:
                lines = file.readlines()
                encodings[file_name[:-4]] = [float(line.strip()) for line in lines]
    return encodings

def find_nearest_match(unknown_encoding, known_encodings):
    best_match_name = None
    best_distance = float('inf')
    for name, known_encoding in known_encodings.items():
        distance = face_recognition.face_distance([known_encoding], unknown_encoding)[0]
        if distance < best_distance:
            best_distance = distance
            best_match_name = name
    
    if best_distance > 0.4:
        return "No matching child found", None
    
    return best_match_name, best_distance

def get_data(image_path, known_encodings_folder):
    recognized_names = recognize_faces_in_image(image_path, known_encodings_folder)

    if recognized_names:
        # Fetch data from the database for recognized names
        results = []
        for name in recognized_names:
            person = Person.query.filter_by(ImageName=name).first()
            if person:
                results.append(person.__dict__)

        return results
    else:
        return []

# Variable to store the results (define in the global scope)
stored_results = {}

def process_uploaded_file(file):
    if not file:
        return "No file part", 400
     
    # Save the uploaded file
    filename = secure_filename(file.filename)
    file_path = os.path.join(app.config['UPLOAD_FOLDER'], filename)
    file.save(file_path)
    
    # Path to the folder containing known encodings
    known_encodings_folder = os.path.join(app.root_path, "C:\\Users\\esraa\\OneDrive\\flask app with sql server and excel2\\flask app with api\\Children Images to Arrays")

    # Get face recognition results
    results = get_data(file_path, known_encodings_folder)
    
    if not results:  # If results are empty
        stored_results['message'] = "There is no matching"
    else:
        stored_results['message'] = "Results found!"
    
    return redirect(url_for('show_prediction'))

@app.route('/upload', methods=['POST'])
def upload_image():
    try:
        # Check if a file was uploaded
        if 'file' not in request.files:
            return "No file part", 400

        # Process the uploaded file
        file = request.files['file']
        process_uploaded_file(file)

    except Exception as e:
        return str(e), 500

    # Redirect to show_prediction route after processing the uploaded file
    return redirect(url_for('show_prediction'))

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/prediction')
def show_prediction():
    message = stored_results.get('message', "No result available")
    return render_template('prediction.html', message=message)

if __name__ == '__main__':
    app.run(debug=True, port=5000)
